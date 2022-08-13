using Aniverse.Application.DTOs.Common;
using Aniverse.Services.Abstractions.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Aniverse.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public PostsController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        [HttpGet("user/{username}")]
        public async Task<IActionResult> GetAllByUser([FromRoute] string username, [FromQuery] PaginationQuery query)
            => Ok(await _unitOfWorkService.PostService.GetAllByUserAsync(username, query));
        [HttpGet("user/login")]
        public async Task<IActionResult> GetAllByLoginUser([FromQuery] PaginationQuery query)
            => Ok(await _unitOfWorkService.PostService.GetAllByLoginUserAsync(query));
    }
}
