﻿using Aniverse.Services.Abstractions.UnitOfWork;
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
        [HttpGet("{username}")]
        public async Task<IActionResult> GetAsync([FromRoute] string username)
            => Ok(await _unitOfWorkService.UserService.GetAsync(username));
        [HttpGet]
        public async Task<ActionResult> Get()
            => Ok(await _unitOfWorkService.UserService.GetAllAsync());

    }
}
