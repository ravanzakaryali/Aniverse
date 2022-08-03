using Aniverse.Application.DTOs.Auth;
using Aniverse.Application.DTOs.User;

namespace Aniverse.Services.Abstractions
{
    public interface IAuthService
    {
        Task<CreateUserResponse> RegisterAsync(Register register);
        Task<Token> LoginAsync(string username, string password, int accessTokenLifeTime = 15);
        Task<Token> RefreshTokenLoginAsync(string username, string refreshToken);
    }
}
