using Aniverse.Application.DTOs.Common;
using Aniverse.Services.Abstractions.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aniverse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        readonly IUnitOfWorkService _unitOfWorkService;

        public UsersController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] PaginationQuery query)
            => Ok(await _unitOfWorkService.UserService.GetAllAsync(query));

        [HttpGet("{username}")]
        public async Task<IActionResult> GetAsync([FromRoute] string username)
            => Ok(await _unitOfWorkService.UserService.GetAsync(username));

        [HttpGet("getLogin")]
        public async Task<IActionResult> GetLoginAsync()
            => Ok(await _unitOfWorkService.UserService.GetLoginAsync());

        [HttpPost("{username}/folow")]
        public async Task<IActionResult> FollowAsync([FromRoute] string username)
        {
            await _unitOfWorkService.UserService.FollowAsync(username);
            return NoContent();
        }
        [HttpPost("{username}/unfollow")]
        public async Task<IActionResult> UnfollowAsync([FromRoute] string username)
        {
            await _unitOfWorkService.UserService.UnfollowAsync(username);
            return NoContent();
        }
       
    }
}
