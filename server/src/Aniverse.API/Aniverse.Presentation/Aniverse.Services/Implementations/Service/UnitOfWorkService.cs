﻿using Aniverse.Application.Abstractions.Services;
using Aniverse.Application.Abstractions.UnitOfWork;
using Aniverse.Domain.Entities.Identity;
using Aniverse.Services.Abstractions;
using Aniverse.Services.Abstractions.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace Aniverse.Services.Implementations.Service
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        public UnitOfWorkService(
            IUnitOfWork unitOfWork, 
            ITokenHandler tokenHandler, 
            SignInManager<AppUser> signInManager, 
            UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        private IAnimalService _animalService;
        private IAuthService _authService;
        private IUserService _userService;
        
        public IAnimalService AnimalService => _animalService ??= new AnimalService();
        public IAuthService AuthService => _authService ??= new AuthService(
            _unitOfWork,
            _userManager,
            _signInManager,
            _tokenHandler);
        public IUserService UserService => _userService ??= new UserService();
    }
}