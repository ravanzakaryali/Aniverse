using Aniverse.Core.Repositories.Abstraction.Base;
using Aniverse.Domain.Entities;

namespace Aniverse.Application.Abstractions.Repositories
{
    public interface ICommentRepository : IRepository<Comment,string>
    {
    }
}
