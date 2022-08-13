using Aniverse.Application.Abstractions.Repositories;
using Aniverse.Domain.Entities;
using Aniverse.Persistence.Context;
using Aniverse.Persistence.Implementations.Repositories.Base;

namespace Aniverse.Persistence.Implementations.Repositories
{
    public class LikeRepository : Repository<Like, string>, ILikeRepository
    {
        public LikeRepository(AniverseDbContext context) : base(context)
        {
        }
    }
}
