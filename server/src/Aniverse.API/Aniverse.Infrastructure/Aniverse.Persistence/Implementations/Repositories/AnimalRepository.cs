using Aniverse.Core.Repositories.Abstraction;
using Aniverse.Domain.Entities;
using Aniverse.Persistence.Context;
using Aniverse.Persistence.Implementations.Repositories.Base;

namespace Aniverse.Persistence.Implementations.Repositories
{
    public class AnimalRepository : Repository<Animal, string>, IAnimalRepository
    {
        public AnimalRepository(AniverseDbContext context) : base(context)
        {
        }
    }
}
