using Aniverse.Application.Abstractions.Repositories;
using Aniverse.Domain.Entities;
using Aniverse.Persistence.Context;
using Aniverse.Persistence.Implementations.Repositories.Base;

namespace Aniverse.Persistence.Implementations.Repositories
{
    public class CommentRepository : Repository<Comment, string>, ICommentRepository
    {
        public CommentRepository(AniverseDbContext context) : base(context)
        {
        }
    }
}
