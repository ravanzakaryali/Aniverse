using Aniverse.Application.DTOs.Common;
using Aniverse.Services.Abstractions.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Aniverse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
