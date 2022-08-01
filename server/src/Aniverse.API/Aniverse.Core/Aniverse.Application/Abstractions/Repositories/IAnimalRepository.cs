using Aniverse.Core.Repositories.Abstraction.Base;
using Aniverse.Domain.Entities;

namespace Aniverse.Core.Repositories.Abstraction
{
    public interface IAnimalRepository : IRepository<Animal,string>
    {
    }
}
