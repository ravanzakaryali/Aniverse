using Aniverse.Application.Abstractions.UnitOfWork;
using Aniverse.Application.DTOs.Common;
using Aniverse.Application.DTOs.User;
using Aniverse.Application.Extensions;
using Aniverse.Domain.Entities;
using Aniverse.Domain.Entities.Identity;
using Aniverse.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;

namespace Aniverse.Services.Implementations
{

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _claim;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor claim)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claim = claim;
        }
        public async Task<UserGetDto> GetLoginAsync()
        {
            string username = _unitOfWork.UserRepository.GetLoginUsername();
            UserGetDto user = await _unitOfWork.UserRepository.GetWithSelectAsync(u=> new UserGetDto()
            {
                Bio = u.Bio,
                UserName = u.UserName,
                Birthday = u.Birthday,
                Firstname = u.Firstname,
                Lastname = u.Lastname,
            },u => u.UserName == username);
            if (user is null)
                throw new Exception("User is not found");
            return user;
        }
        public async Task<UserGetDto> GetAsync(string username)
        {
            UserGetDto user = await _unitOfWork.UserRepository
                .GetWithSelectAsync(u => new UserGetDto
                {
                    UserName = u.UserName,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname,
                    Birthday = u.Birthday,
                    Bio = u.Bio
                }, u => u.UserName == username);
            if (user is null)
                throw new Exception("User not found");
            return user;
        }
        public async Task<List<UserGetAll>> GetAllAsync(PaginationQuery query)
        {
            List<UserGetAll> users = await _unitOfWork.UserRepository.GetAllWithSelectAsync(query.Page, query.Size, u => u.CreatedDate, u => new UserGetAll
            {
                CreatedDate = u.CreatedDate,
                Firstname = u.Firstname,
                Lastname = u.Lastname,
                UserName = u.UserName
            },isOrderBy: false);

            return users;
        }
        public async Task FollowAsync(string username)
        {
            AppUser user = await _unitOfWork.UserRepository.GetAsync(u=>u.NormalizedUserName == username.ToUpper());
            if (user is null)
                throw new Exception("User not found");
            var userLoginId = _claim.HttpContext.User.GetLoginUserId();
        }
    }
}
