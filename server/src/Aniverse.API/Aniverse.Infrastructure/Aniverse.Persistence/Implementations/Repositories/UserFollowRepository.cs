using Aniverse.Application.Abstractions.Repositories;
using Aniverse.Domain.Entities;
using Aniverse.Persistence.Context;
using Aniverse.Persistence.Implementations.Repositories.Base;

namespace Aniverse.Persistence.Implementations.Repositories
{
    public class UserFollowRepository : Repository<UserFollow, Guid>, IUserFollowRepository
    {
        public UserFollowRepository(AniverseDbContext context) : base(context)
        {
        }
    }
}
