using Aniverse.Application.DTOs.Comment;
using Aniverse.Application.DTOs.Common;
using Aniverse.Application.DTOs.Post;
using Aniverse.Application.DTOs.User;

namespace Aniverse.Services.Abstractions
{
    public interface IPostService
    {
        Task<List<PostGetDto>> GetAllByUserAsync(string username, PaginationQuery query = null);
        Task<List<PostGetDto>> GetAllByLoginUserAsync(PaginationQuery query = null);
        Task<List<UserGetAll>> GetAllUserLikesPostAsync(string postId, PaginationQuery query = null);
        Task<List<CommentGet>> GetAllPostCommentsAsync(string postId, PaginationQuery query = null);
        Task<List<PostGetWithAnimalDto>> GetAllByAnimalAsync(string animalname, PaginationQuery query = null);
    }
}
