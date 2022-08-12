using Aniverse.Application.Abstractions.Repositories;
using Aniverse.Core.Repositories.Abstraction;

namespace Aniverse.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPostRepository PostRepository { get; }
        IUserRepository UserRepository { get; }
        IAnimalRepository AnimalRepository { get; }
        IAnimalFollowRepository AnimalFollowRepository { get; }
        IUserFollowRepository UserFollowRepository { get; }
        Task SaveAsync();
    }
}
