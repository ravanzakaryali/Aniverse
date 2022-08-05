using Aniverse.Application.DTOs.Auth;
using Aniverse.Domain.Entities.Identity;
using System.Security.Claims;

namespace Aniverse.Application.Abstractions.Services
{
    public interface ITokenHandler
    {
        Task<Token> CreateAccessTokenAsync(AppUser user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        string CreateRefreshToken();
    }
}
