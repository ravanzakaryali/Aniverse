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
                Lastname = model.Firtname,
                Email = model.Email,
                UserName = model.Email.CharacterRegulatory(),
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
        public async Task<Token> LoginAsync(string username, string password, int accessTokenLifeTime = 15)
        {
            AppUser user = await _userManager.FindByNameAsync(username);
            if (user is null)
                throw new Exception("User not found");
            if (!user.EmailConfirmed)
                throw new Exception("Please email confirmed");
            SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!signInResult.Succeeded)
                throw new Exception("Password and Username is wrong");
            Token token = await _tokenHandler.CreateAccessTokenAsync(user);
            await UpdateRefreshToken(user.RefreshToken, user, token.Expiration, accessTokenLifeTime);
            return token;
        }
        public async Task<Token> RefreshTokenLoginAsync(string username, string refreshToken)
        {
            AppUser user = await _userManager.FindByNameAsync(username);
            if (user is null)
                throw new Exception("User not found");
            if (user.RefreshToken != refreshToken)
                throw new Exception("Token is valid");
            Token token = await _tokenHandler.CreateAccessTokenAsync(user);
            await UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 15);
            return token;
        }
    }
}
