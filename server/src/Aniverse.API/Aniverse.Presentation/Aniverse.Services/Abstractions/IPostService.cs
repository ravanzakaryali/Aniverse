using Aniverse.Application.DTOs.Common;
using Aniverse.Application.DTOs.Post;
using Aniverse.Application.DTOs.User;

namespace Aniverse.Services.Abstractions
{
    public interface IPostService
    {
        Task<List<PostGetDto>> GetAllByUserAsync(string username, PaginationQuery query);
        Task<List<PostGetDto>> GetAllByLoginUserAsync(PaginationQuery query);
        Task<List<UserGetAll>> GetAllUserLikesPostAsync(string postId, PaginationQuery query = null);

    }
}
