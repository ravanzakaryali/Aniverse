using Aniverse.Application.Abstractions.Services;
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
        private readonly ITokenHandler _tokenHandler;
        private readonly SignInManager<AppUser> _signInManager;
        public UnitOfWork(
            AniverseDbContext context,
            UserManager<AppUser> userManager,
            ITokenHandler tokenHandler, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
        }
        private IPostRepository _postRepository;
        private IAnimalRepository _animalRepository;
        private IUserRepository _userRepository;
        public IPostRepository PostRepository => _postRepository ??= new PostRepository(_context);
        public IAnimalRepository AnimalRepository => _animalRepository ??= new AnimalRepository(_context);
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context, _userManager, _tokenHandler,_signInManager);
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
