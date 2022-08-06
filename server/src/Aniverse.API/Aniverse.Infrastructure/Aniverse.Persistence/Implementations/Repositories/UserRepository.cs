using Aniverse.Application.Abstractions.Services;
using Aniverse.Application.DTOs.Auth;
using Aniverse.Application.DTOs.User;
using Aniverse.Application.Extensions;
using Aniverse.Core.Repositories.Abstraction;
using Aniverse.Domain.Entities.Identity;
using Aniverse.Persistence.Context;
using Aniverse.Persistence.Implementations.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace Aniverse.Persistence.Implementations.Repositories
{
    public class UserRepository : Repository<AppUser, string>, IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AniverseDbContext _context;
        public UserRepository(
            AniverseDbContext context,
            UserManager<AppUser> userManager,
            ITokenHandler tokenHandler, SignInManager<AppUser> signInManager) : base(context)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
        }
        public async Task<CreateUserResponse> CreateAsync(Register model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Firstname = model.Firtname,
                Lastname = model.Lastname,
                Email = model.Email,
                UserName = await GenerateUsernameAsync(model.Firtname + model.Lastname),
            }, model.Password);
            CreateUserResponse response = new() { Succeeded = result.Succeeded };
            if (result.Succeeded)
                response.Message = "Please confirm email";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }
        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = accessTokenDate.AddDays(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new Exception("User not found");
            }
        }
        private async Task<string> GenerateUsernameAsync(string fullname, int maxLenght = 20)
        {
            string username = (fullname.CharacterRegulatory() + Guid.NewGuid().ToString("N"))[..maxLenght];
            AppUser isUserName = await _userManager.FindByNameAsync(username);
            if (isUserName != null)
            {

                await GenerateUsernameAsync(fullname, maxLenght += 1);
            }
            return username;
        }
    }
}
