using Aniverse.Domain.Entities;
using Aniverse.Persistence.Repositories.Abstraction.Base;
using System.Reflection;

namespace Aniverse.Persistence.Repositories.Abstraction
{
    public interface IPostRepository : IBaseRepository<Post,string>
    {
    }
}
