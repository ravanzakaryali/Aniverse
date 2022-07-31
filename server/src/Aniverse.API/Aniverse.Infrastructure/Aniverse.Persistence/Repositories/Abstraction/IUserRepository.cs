using Aniverse.Domain.Entities.Identity;
using Aniverse.Persistence.Repositories.Abstraction.Base;

namespace Aniverse.Persistence.Repositories.Abstraction
{
    public interface IUserRepository : IBaseRepository<AppUser, string>
    {
    }
}
