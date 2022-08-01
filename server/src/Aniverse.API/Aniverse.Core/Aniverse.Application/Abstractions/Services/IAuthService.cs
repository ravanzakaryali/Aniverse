using Aniverse.Application.Abstractions.Services.Authentications;

namespace Aniverse.Application.Abstractions.Services
{
    public interface IAuthService : IExternalAuthetication, IInternalAuthentication
    {
    }
}
