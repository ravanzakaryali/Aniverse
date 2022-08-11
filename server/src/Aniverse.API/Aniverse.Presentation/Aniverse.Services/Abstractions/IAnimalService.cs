using Aniverse.Application.DTOs.Animal;
using Aniverse.Application.DTOs.Common;

namespace Aniverse.Services.Abstractions
{
    public interface IAnimalService
    {
        Task<AnimalGetDto> GetAsync(string animalname);
        Task<List<AnimalGetAll>> GetAllAsync(PaginationQuery query);
        Task<AnimalGetDto> Create(AnimalCreateDto animal);
        Task FollowAsync(string animalname);
    }
}
