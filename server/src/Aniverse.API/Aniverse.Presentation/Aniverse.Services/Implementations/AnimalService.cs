using Aniverse.Application.Abstractions.UnitOfWork;
using Aniverse.Application.DTOs.Animal;
using Aniverse.Application.DTOs.Common;
using Aniverse.Application.Extensions;
using Aniverse.Domain.Entities;
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
            Animal animal = await _unitOfWork.AnimalRepository.GetAsync(a => a.Animalname == animalname, include: "User");
            if (animal is null)
                throw new Exception("Animal not found");
            return _mapper.Map<AnimalGetDto>(animal);
        }
        public async Task<List<AnimalGetAll>> GetAllAsync(PaginationQuery query)
        {
            return _mapper.Map<List<AnimalGetAll>>(await _unitOfWork.AnimalRepository.GetAllAsync(query.Page, query.Size, a => a.CreatedDate, predicate: null, includes: "User"));
        }
        public async Task<AnimalGetDto> Create(AnimalCreateDto animal)
        {
            Animal createAnimal = _mapper.Map<Animal>(animal);
            createAnimal.UserId = _claims.HttpContext.User.GetLoginUserId();
            createAnimal.Animalname = await GenerateAnimalnameAsync(animal.Name);
            Animal newAnimal = await _unitOfWork.AnimalRepository.AddAsync(createAnimal);
            return _mapper.Map<AnimalGetDto>(newAnimal);
        }
        private async Task<string> GenerateAnimalnameAsync(string fullname, int maxLenght = 10)
        {
            string animalname = (fullname.CharacterRegulatory() + Guid.NewGuid().ToString("N"))[..maxLenght];
            Animal isAnimalname = await _unitOfWork.AnimalRepository.GetAsync(a => a.Animalname == animalname);
            if (isAnimalname != null)
            {
                await GenerateAnimalnameAsync(fullname, maxLenght += 1);
            }
            return animalname;
        }

    }
}
