using Aniverse.Domain.Entities;
using Aniverse.Persistence.Repositories.Abstraction.Base;

namespace Aniverse.Persistence.Repositories.Abstraction
{
    public interface IPostRepository : IRepository<Post,string>
    {
    }
}
