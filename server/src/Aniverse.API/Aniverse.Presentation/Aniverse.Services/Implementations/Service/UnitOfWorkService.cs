using Aniverse.Services.Abstractions;
using Aniverse.Services.Abstractions.UnitOfWork;

namespace Aniverse.Services.Implementations.Service
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private IAnimalService _animalService;
        private IAuthService _authService;
        private IUserService _userService;
        public IAnimalService AnimalService => _animalService ??= new AnimalService();
        public IAuthService AuthService => _authService ??= new AuthService();
        public IUserService UserService => _userService ??= new UserService();
    }
}
