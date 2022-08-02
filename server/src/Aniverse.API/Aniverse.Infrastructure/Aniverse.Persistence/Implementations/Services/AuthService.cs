using Aniverse.Application.Abstractions.Services;
using Aniverse.Application.DTOs.Auth;
using Aniverse.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Aniverse.Persistence.Implementations.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;

        public AuthService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenHandler tokenHandler,
            IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
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
            await _userService.UpdateRefreshToken(user.RefreshToken, user, token.Expiration, accessTokenLifeTime);
            return token;
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user is null)
                throw new NotImplementedException();
            Token token = await _tokenHandler.CreateAccessTokenAsync(user);
            await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 15);
            return token;
        }
    }
}
