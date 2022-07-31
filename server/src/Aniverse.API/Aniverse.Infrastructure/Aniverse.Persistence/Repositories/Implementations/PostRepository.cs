using Aniverse.Domain.Entities;
using Aniverse.Persistence.Context;
using Aniverse.Persistence.Repositories.Abstraction;
using Aniverse.Persistence.Repositories.Implementations.Base;

namespace Aniverse.Persistence.Repositories.Implementations
{
    public class PostRepository : Repository<Post, string>, IPostRepository
    {
        public PostRepository(AniverseDbContext context) : base(context)
        {
        }
    }
}
