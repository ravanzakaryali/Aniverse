using Aniverse.Application.Abstractions.Services.Authentications;
using Aniverse.Application.DTOs.Auth;

namespace Aniverse.Application.Abstractions.Services
{
    public interface IAuthService : IExternalAuthetication, IInternalAuthentication
    {
    }
}
