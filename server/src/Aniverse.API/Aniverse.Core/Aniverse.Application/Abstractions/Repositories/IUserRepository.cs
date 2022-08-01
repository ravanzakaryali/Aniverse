using Aniverse.Core.Repositories.Abstraction.Base;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Core.Repositories.Abstraction
{
    public interface IUserRepository : IRepository<AppUser, string>
    {
    }
}
