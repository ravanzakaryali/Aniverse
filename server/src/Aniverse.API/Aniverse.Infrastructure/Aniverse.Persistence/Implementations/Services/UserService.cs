﻿using Aniverse.Application.Abstractions.Services;
using Aniverse.Application.DTOs.Auth;
using Aniverse.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Aniverse.Application.Extensions;

namespace Aniverse.Persistence.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterResponse> CreateAsync(Register model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Firstname = model.Firtname,
                Lastname = model.Firtname,
                Email = model.Email,
                UserName = model.Email.CharacterRegulatory(),
            });
            RegisterResponse response = new() { Succeeded = result.Succeeded };
            if (result.Succeeded)
                response.Message = "Please confirm email";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }

        public Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            throw new NotImplementedException();
        }
    }
}
