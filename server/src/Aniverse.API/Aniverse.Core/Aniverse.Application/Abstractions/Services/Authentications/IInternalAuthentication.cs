using Aniverse.Application.DTOs.Auth;

namespace Aniverse.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<Token> LoginAsync(string username, string password);
        Task<Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
