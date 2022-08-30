using Aniverse.Core.Repositories.Abstraction;
using Aniverse.Domain.Entities;
using Aniverse.Persistence.Context;
using Aniverse.Persistence.Implementations.Repositories.Base;

namespace Aniverse.Persistence.Implementations.Repositories
{
    public class PostRepository : Repository<Post, string>, IPostRepository
    {
        public PostRepository(AniverseDbContext context) : base(context) { }
    }
}
