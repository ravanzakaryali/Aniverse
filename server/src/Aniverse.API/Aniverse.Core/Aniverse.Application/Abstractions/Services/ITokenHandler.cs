using Aniverse.Application.DTOs.Auth;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Application.Abstractions.Services
{
    public interface ITokenHandler
    {
        Task<Token> CreateAccessTokenAsync(AppUser user);
        string CreateRefreshToken();
    }
}
