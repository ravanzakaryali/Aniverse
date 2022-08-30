using Aniverse.Application.Abstractions.UnitOfWork;
using Aniverse.Application.DTOs.Animal;
using Aniverse.Application.DTOs.Common;
using Aniverse.Application.DTOs.User;
using Aniverse.Application.Extensions;
using Aniverse.Application.Statics;
using Aniverse.Domain.Entities;
using Aniverse.Domain.Entities.Identity;
using Aniverse.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Aniverse.Services.Implementations
{
    public class AnimalService : IAnimalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _claims;

        public AnimalService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor claims)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claims = claims;
        }
        public async Task<AnimalGetDto> GetAsync(string animalname)
        {
            Animal animal = await _unitOfWork.AnimalRepository.GetAsync(a => a.Animalname == animalname, include: "User", tracking: false);
            if (animal is null)
                throw new Exception("Animal not found");
            return _mapper.Map<AnimalGetDto>(animal);
        }
        public async Task<List<AnimalGetAll>> GetAllAsync(PaginationQuery query)
        {
            return _mapper.Map<List<AnimalGetAll>>(await _unitOfWork.AnimalRepository.GetAllAsync(query.Page, query.Size, a => a.CreatedDate, predicate: null,tracking: false, includes: "User"));
        }
        public async Task<AnimalGetDto> Create(AnimalCreateDto animal)
        {
            Animal createAnimal = _mapper.Map<Animal>(animal);
            createAnimal.UserId = _claims.HttpContext.User.GetLoginUserId();
            createAnimal.Animalname = await GenerateAnimalnameAsync(animal.Name);
            Animal newAnimal = await _unitOfWork.AnimalRepository.AddAsync(createAnimal);
            return _mapper.Map<AnimalGetDto>(newAnimal);
        }
        public async Task FollowAsync(string animalname)
        {
            Animal animal = await _unitOfWork.AnimalRepository.GetAsync(a=>a.NormalizedAnimalname == animalname.ToUpper());
            if (animal is null)
                throw new Exception("Animal not found");
            var userLoginId = _claims.HttpContext.User.GetLoginUserId();
            AnimalFollow animalFollowDb = await _unitOfWork.AnimalFollowRepository.GetAsync(a=>a.UserId == userLoginId && a.AnimalId == animal.Id);
            if (animalFollowDb is not null)
                throw new Exception("Already animal follow");
            AnimalFollow animalFollow = new()
            {
                UserId = userLoginId,
                AnimalId = animal.Id,
            };
            await _unitOfWork.AnimalFollowRepository.AddAsync(animalFollow);
        }
        public async Task UnfollowAsync(string animalname)
        {
            Animal animal = await _unitOfWork.AnimalRepository.GetAsync(a => a.NormalizedAnimalname == animalname.ToUpper());
            if (animal is null)
                throw new Exception("Animal not found");
            var userLoginId = _claims.HttpContext.User.GetLoginUserId();
            AnimalFollow animalFollowDb = await _unitOfWork.AnimalFollowRepository.GetAsync(a => a.UserId == userLoginId && a.AnimalId == animal.Id);
            if (animalFollowDb is null)
                throw new Exception("animal follow not found");
            _unitOfWork.AnimalFollowRepository.Remove(animalFollowDb);
            await _unitOfWork.SaveAsync();
        }
        #region GenerateUsernameAnimal
        private async Task<string> GenerateAnimalnameAsync(string fullname, int maxLenght = 10)
        {
            string animalname = (StringHelper.CharacterRegulatory(fullname) + Guid.NewGuid().ToString("N"))[..maxLenght];
            Animal isAnimalname = await _unitOfWork.AnimalRepository.GetAsync(a => a.Animalname == animalname);
            if (isAnimalname != null)
            {
                await GenerateAnimalnameAsync(fullname, maxLenght += 1);
            }
            return animalname;
        }
        #endregion
    }
}
