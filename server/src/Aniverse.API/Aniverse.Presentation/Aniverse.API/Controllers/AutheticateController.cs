using Aniverse.Application.DTOs.Auth;
using Aniverse.Services.Abstractions.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Aniverse.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AutheticateController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public AutheticateController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync([FromForm] Register register)
            => Ok(await _unitOfWorkService.AuthService.RegisterAsync(register));

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] Login login)
            => Ok(await _unitOfWorkService.AuthService.LoginAsync(login));

        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken([FromForm] TokenRequest tokenModel)
            => Ok(await _unitOfWorkService.AuthService.RefreshTokenLoginAsync(tokenModel));

    }
}
