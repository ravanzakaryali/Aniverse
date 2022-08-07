using Aniverse.Application.DTOs.Auth;
using Aniverse.Application.DTOs.Common;
using Aniverse.Application.DTOs.User;
using Aniverse.Core.Repositories.Abstraction.Base;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Core.Repositories.Abstraction
{
    public interface IUserRepository : IRepository<AppUser, string>
    {
        string GetLoginUsername();
        Task<CreateUserResponse> CreateAsync(Register model);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
