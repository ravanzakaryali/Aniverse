using Aniverse.Application.Abstractions.UnitOfWork;
using Aniverse.Application.DTOs.User;
using Aniverse.Domain.Entities.Identity;
using Aniverse.Services.Abstractions;
using AutoMapper;

namespace Aniverse.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserGetDto> GetAsync(string username)
        {
            AppUser user = await _unitOfWork.UserRepository.GetAsync(u=>u.UserName == username);
            if (user is null)
                throw new Exception("User not found");
            return _mapper.Map<UserGetDto>(user);
        }
        public async Task<List<UserGetAll>> GetAllAsync()
        {
            return _mapper.Map<List<UserGetAll>>(await _unitOfWork.UserRepository.GetAllAsync());
        }
    }
}
