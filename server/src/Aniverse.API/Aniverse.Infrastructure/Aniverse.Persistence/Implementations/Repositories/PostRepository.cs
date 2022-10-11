using Aniverse.Core.Repositories.Abstraction;
using Aniverse.Domain.Entities;
using Aniverse.Persistence.Context;
using Aniverse.Persistence.Implementations.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Aniverse.Persistence.Implementations.Repositories
{
    public class PostRepository : Repository<Post, string>, IPostRepository
    {
        private AniverseDbContext _context;
        public PostRepository(AniverseDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
