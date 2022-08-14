using Aniverse.Application.Abstractions.UnitOfWork;
using Aniverse.Application.DTOs.Comment;
using Aniverse.Application.DTOs.Common;
using Aniverse.Application.DTOs.Post;
using Aniverse.Application.DTOs.User;
using Aniverse.Application.Extensions;
using Aniverse.Domain.Entities;
using Aniverse.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Aniverse.Services.Implementations
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public readonly IHttpContextAccessor _claim;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor claim)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claim = claim;
        }
        public async Task<List<PostGetDto>> GetAllByUserAsync(string username, PaginationQuery query)
        {
            var user = await _unitOfWork.UserRepository.GetWithSelectAsync(u => new { u.UserName, u.Id }, u => u.NormalizedUserName == username.ToUpper());
            if (user is null)
                throw new Exception("User not found");
            List<Post> post = await _unitOfWork.PostRepository.GetAllAsync(query.Page, query.Size, p => p.CreatedDate, p => p.UserId == user.Id, tracking: false, includes: "User");
            return _mapper.Map<List<PostGetDto>>(post);
        }
        public async Task<List<PostGetDto>> GetAllByLoginUserAsync(PaginationQuery query)
        {
            var userLoginId = _claim.HttpContext.User.GetLoginUserId();
            var user = await _unitOfWork.UserRepository.GetWithSelectAsync(u => new { u.UserName, u.Id }, u => u.Id == userLoginId);
            if (user is null)
                throw new Exception("User not found");
            List<Post> post = await _unitOfWork.PostRepository.GetAllAsync(query.Page, query.Size, p => p.CreatedDate, p => p.UserId == user.Id, tracking: false, includes: "User");
            return _mapper.Map<List<PostGetDto>>(post);
        }
        public async Task<List<UserGetAll>> GetAllUserLikesPostAsync(string postId, PaginationQuery query = null)
        {
            query ??= new PaginationQuery(1, 10);
            var post = await _unitOfWork.PostRepository.GetAsync(p => p.Id.ToString() == postId);
            if (post is null)
                throw new Exception("Post not found");
            return await _unitOfWork.LikeRepository.GetAllWithSelectAsync(page: query.Page, size: query.Size, l => l.CreatedDate, l => new UserGetAll
            {
                Firstname = l.User.Firstname,
                Lastname = l.User.Lastname,
                UserName = l.User.UserName,
            }, u => u.PostId == post.Id, includes: "User");
        }
        public async Task<List<CommentGet>> GetAllPostCommentsAsync(string postId, PaginationQuery query = null)
        {
            query ??= new PaginationQuery(1, 5);
            var post = await _unitOfWork.PostRepository.GetWithSelectAsync(p => new { p.Id }, p => p.Id.ToString() == postId);
            if (post is null)
                throw new Exception("Post not found");
            return await _unitOfWork.CommentRepository.GetAllWithSelectAsync(page: query.Page, size: query.Size, c => c.CreatedDate, c => new CommentGet
            {
                Content = c.Content,
                CreatedDate = c.CreatedDate,
                ReplyCommentsId = c.ReplyCommentsId,
                PostId = c.PostId,
                User = _mapper.Map<UserGetAll>(c.User)
            }, c => c.PostId == post.Id, includes: "User");
        }
    }
}
