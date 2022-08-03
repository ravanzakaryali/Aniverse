using Aniverse.Application.DTOs.Auth;
using Aniverse.Application.DTOs.User;
using Aniverse.Core.Repositories.Abstraction.Base;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Core.Repositories.Abstraction
{
    public interface IUserRepository : IRepository<AppUser, string>
    {
        Task<Token> LoginAsync(string username, string password, int accessTokenLifeTime = 15);
        Task<Token> RefreshTokenLoginAsync(string username, string refreshToken);
        Task<CreateUserResponse> CreateAsync(Register model);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
