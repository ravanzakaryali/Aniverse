using Aniverse.Application.Abstractions.Repositories;
using Aniverse.Domain.Entities;
using Aniverse.Persistence.Context;
using Aniverse.Persistence.Implementations.Repositories.Base;

namespace Aniverse.Persistence.Implementations.Repositories
{
    public class AnimalFollowRepository : Repository<AnimalFollow, Guid>, IAnimalFollowRepository
    {
        public AnimalFollowRepository(AniverseDbContext context) : base(context)
        {
        }

    }
}
