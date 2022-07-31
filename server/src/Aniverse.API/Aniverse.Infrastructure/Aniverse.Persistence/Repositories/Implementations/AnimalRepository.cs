using Aniverse.Domain.Entities;
using Aniverse.Persistence.Context;
using Aniverse.Persistence.Repositories.Abstraction;
using Aniverse.Persistence.Repositories.Implementations.Base;

namespace Aniverse.Persistence.Repositories.Implementations
{
    public class AnimalRepository : Repository<Animal, string>, IAnimalRepository
    {
        public AnimalRepository(AniverseDbContext context) : base(context)
        {
        }
    }
}
