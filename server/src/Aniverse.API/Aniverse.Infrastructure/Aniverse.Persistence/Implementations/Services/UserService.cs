using Aniverse.Application.Abstractions.Services;
using Aniverse.Application.DTOs.Auth;
using Aniverse.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Aniverse.Persistence.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<RegisterReponse> CreateAsync(Register model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            throw new NotImplementedException();
        }
    }
}
