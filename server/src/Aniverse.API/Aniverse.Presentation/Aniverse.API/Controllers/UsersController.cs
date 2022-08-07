using Aniverse.Application.DTOs.Common;
using Aniverse.Services.Abstractions.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aniverse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

    }
}
