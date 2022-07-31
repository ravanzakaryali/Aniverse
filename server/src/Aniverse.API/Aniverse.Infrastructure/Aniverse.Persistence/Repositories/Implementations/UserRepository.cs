using Aniverse.Domain.Entities.Identity;
using Aniverse.Persistence.Context;
using Aniverse.Persistence.Repositories.Abstraction;
using Aniverse.Persistence.Repositories.Implementations.Base;
using Microsoft.AspNetCore.Identity;

namespace Aniverse.Persistence.Repositories.Implementations
{
    public class UserRepository : Repository<AppUser, string>, IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        public UserRepository(AniverseDbContext context, 
                            UserManager<AppUser> userManager) : base(context)
        {
            _userManager = userManager;
        }
    }
}
