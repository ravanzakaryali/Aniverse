using Aniverse.Core.Repositories.Abstraction;

namespace Aniverse.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPostRepository PostRepository { get; }
        IUserRepository UserRepository { get; }
        IAnimalRepository AnimalRepository { get; }
        Task SaveAsync();
    }
}
