using Aniverse.Application.Abstractions.Services;
using Aniverse.Application.DTOs.Auth;

namespace Aniverse.Persistence.Implementations.Services
{
    public class AuthService : IAuthService
    {
        public Task<Token> LoginAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
