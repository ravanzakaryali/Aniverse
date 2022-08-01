using Aniverse.Application.DTOs.Auth;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<RegisterReponse> CreateAsync(Register model);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
