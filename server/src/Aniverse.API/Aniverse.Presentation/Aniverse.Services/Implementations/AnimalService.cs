using Aniverse.Application.Abstractions.UnitOfWork;
using Aniverse.Application.DTOs.Animal;
using Aniverse.Application.DTOs.Common;
using Aniverse.Domain.Entities;
using Aniverse.Services.Abstractions;
using AutoMapper;

namespace Aniverse.Services.Implementations
{
    public class AnimalService : IAnimalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnimalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
    }
}
