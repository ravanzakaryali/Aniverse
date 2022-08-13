using Aniverse.Application.DTOs.Common;
using Aniverse.Services.Abstractions.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Aniverse.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class PostsControllers : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public PostsControllers(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        [HttpGet("{username}")]
        public async Task<IActionResult> GetAllByUser([FromRoute] string username, [FromQuery] PaginationQuery query)
            => Ok(await _unitOfWorkService.PostService.GetAllByUser(username, query));
    }
}
