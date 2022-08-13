using Aniverse.Application.Abstractions.UnitOfWork;
using Aniverse.Application.DTOs.Common;
using Aniverse.Application.DTOs.Post;
using Aniverse.Domain.Entities;
using Aniverse.Domain.Entities.Identity;
using Aniverse.Services.Abstractions;
using AutoMapper;

namespace Aniverse.Services.Implementations
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<PostGetDto>> GetAllByUser(string username, PaginationQuery query)
        {
            var user = await _unitOfWork.UserRepository.GetWithSelectAsync(u => new { u.UserName, u.Id }, u => u.NormalizedUserName == username.ToUpper());
            if (user is null)
                throw new Exception("User not found");
            List<Post> post = await _unitOfWork.PostRepository.GetAllAsync(query.Page, query.Size, p => p.CreatedDate, p => p.UserId == user.Id, tracking: false, includes: "User");
            return _mapper.Map<List<PostGetDto>>(post);
        }
    }
}
