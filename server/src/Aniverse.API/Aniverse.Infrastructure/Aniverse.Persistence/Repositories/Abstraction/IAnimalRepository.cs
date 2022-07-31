using Aniverse.Domain.Entities;
using Aniverse.Persistence.Repositories.Abstraction.Base;

namespace Aniverse.Persistence.Repositories.Abstraction
{
    public interface IAnimalRepository : IRepository<Animal,string>
    {
    }
}
