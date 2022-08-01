using Aniverse.Application.DTOs.Auth;

namespace Aniverse.Application.Abstractions.Services
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int second);
        string CreateRefreshToken();
    }
}
