using Aniverse.Application.DTOs.Animal;
using Aniverse.Application.DTOs.Common;
using Aniverse.Services.Abstractions.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aniverse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnimalsController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public AnimalsController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        [HttpGet("{animalname}")]
        public async Task<IActionResult> GetAsync([FromRoute] string animalname)
            => Ok(await _unitOfWorkService.AnimalService.GetAsync(animalname));
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery query)
            => Ok(await _unitOfWorkService.AnimalService.GetAllAsync(query));
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AnimalCreateDto animal)
            => Ok(await _unitOfWorkService.AnimalService.Create(animal));
        [HttpPost("{animalname}/follow")]
        public async Task<IActionResult> FollowAsync([FromRoute] string animalname)
        {
            await _unitOfWorkService.AnimalService.FollowAsync(animalname);
            return NoContent();
        }
        [HttpPost("{animalname}/unfollow")]
        public async Task<IActionResult> UnfollowAsync([FromRoute] string animalname)
        {
            await _unitOfWorkService.AnimalService.UnfollowAsync(animalname);
            return NoContent();
        }
    }
}
