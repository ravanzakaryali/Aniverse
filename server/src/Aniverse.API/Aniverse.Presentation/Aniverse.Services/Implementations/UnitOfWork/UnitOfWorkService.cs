using Aniverse.Application.Abstractions.Services;
using Aniverse.Application.Abstractions.Storage;
using Aniverse.Application.Abstractions.UnitOfWork;
using Aniverse.Domain.Entities.Identity;
using Aniverse.Services.Abstractions;
using Aniverse.Services.Abstractions.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Aniverse.Services.Implementations.Service
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _claims;
        private readonly IStorageService _storageService;
        public UnitOfWorkService(
            IUnitOfWork unitOfWork,
            ITokenHandler tokenHandler,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager, IMapper mapper, IHttpContextAccessor claims, IStorageService storageService)
        {
            _unitOfWork = unitOfWork;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _claims = claims;
            _storageService = storageService;
        }
        private IAnimalService _animalService;
        private IAuthService _authService;
        private IUserService _userService;
        private IPostService _postService;

        public IAnimalService AnimalService => _animalService ??= new AnimalService(_unitOfWork, _mapper, _claims);
        public IAuthService AuthService => _authService ??= new AuthService(
            _unitOfWork,
            _userManager,
            _signInManager,
            _tokenHandler);
        public IUserService UserService => _userService ??= new UserService(_unitOfWork, _mapper, _claims);
        public IPostService PostService => _postService ??= new PostService(_unitOfWork, _mapper, _claims, _storageService);
    }
}
