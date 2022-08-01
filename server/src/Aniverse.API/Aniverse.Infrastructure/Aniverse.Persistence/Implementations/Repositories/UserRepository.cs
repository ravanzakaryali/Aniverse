using Aniverse.Core.Repositories.Abstraction;
using Aniverse.Domain.Entities.Identity;
using Aniverse.Persistence.Context;
using Aniverse.Persistence.Implementations.Repositories.Base;
using Microsoft.AspNetCore.Identity;

namespace Aniverse.Persistence.Implementations.Repositories
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
