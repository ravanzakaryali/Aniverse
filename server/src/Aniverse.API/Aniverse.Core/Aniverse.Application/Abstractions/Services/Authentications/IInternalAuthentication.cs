using Aniverse.Application.DTOs.Auth;

namespace Aniverse.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<Token> LoginAsync(string username, string password, int accessTokenLifeTime = 15);
        Task<Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
