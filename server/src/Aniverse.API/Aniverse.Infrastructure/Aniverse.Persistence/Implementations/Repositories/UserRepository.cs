using Aniverse.Application.Abstractions.Services;
using Aniverse.Application.DTOs.Auth;
using Aniverse.Application.DTOs.User;
using Aniverse.Application.Extensions;
using Aniverse.Core.Repositories.Abstraction;
using Aniverse.Domain.Entities.Identity;
using Aniverse.Persistence.Context;
using Aniverse.Persistence.Implementations.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace Aniverse.Persistence.Implementations.Repositories
{
    public class UserRepository : Repository<AppUser, string>, IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly SignInManager<AppUser> _signInManager;
        public UserRepository(
            AniverseDbContext context,
            UserManager<AppUser> userManager, 
            ITokenHandler tokenHandler) : base(context)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }
        public async Task<CreateUserResponse> CreateAsync(Register model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Firstname = model.Firtname,
                Lastname = model.Lastname,
                Email = model.Email,
                UserName = await GenerateUsernameAsync(model.Firtname + model.Lastname),
            });
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
                user.RefreshTokenExpiryTime = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new ArgumentException("User not found");
            }
        }
        private async Task<string> GenerateUsernameAsync(string fullname)
        {
            string username = fullname.CharacterRegulatory(30);
            AppUser isUserName = await _userManager.FindByNameAsync(username);
            if (isUserName != null)
            {
                await GenerateUsername(fullname);
            }
            return username;
        }
    }
}
