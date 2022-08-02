using Aniverse.Application.Abstractions.UnitOfWork;
using Aniverse.Core.Repositories.Abstraction;
using Aniverse.Domain.Entities.Identity;
using Aniverse.Persistence.Context;
using Aniverse.Persistence.Implementations.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Aniverse.Persistence.Implementations.UnitOfWrok
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AniverseDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public UnitOfWork(AniverseDbContext context)
        {
            _context = context;
        }
        private IPostRepository _postRepository;
        private IAnimalRepository _animalRepository;
        private IUserRepository _userRepository;
        public IPostRepository PostRepository => _postRepository ??= new PostRepository(_context);
        public IAnimalRepository AnimalRepository => _animalRepository ??= new AnimalRepository(_context);
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context, _userManager);
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
