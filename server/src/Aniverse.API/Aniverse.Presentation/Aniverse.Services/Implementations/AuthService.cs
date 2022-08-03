using Aniverse.Application.Abstractions.Services;
using Aniverse.Application.Abstractions.UnitOfWork;
using Aniverse.Application.DTOs.Auth;
using Aniverse.Application.DTOs.User;
using Aniverse.Domain.Entities.Identity;
using Aniverse.Services.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace Aniverse.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        public AuthService(
            IUnitOfWork unitOfWork, 
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, 
            ITokenHandler tokenHandler)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<CreateUserResponse> RegisterAsync(Register register)
        {
            return await _unitOfWork.UserRepository.CreateAsync(register);
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
            await _unitOfWork.UserRepository.UpdateRefreshToken(user.RefreshToken, user, token.Expiration, accessTokenLifeTime);
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
            await _unitOfWork.UserRepository.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 15);
            return token;
        }
    }
}
