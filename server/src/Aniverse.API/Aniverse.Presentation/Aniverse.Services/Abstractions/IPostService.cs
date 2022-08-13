using Aniverse.Application.DTOs.Common;
using Aniverse.Application.DTOs.Post;

namespace Aniverse.Services.Abstractions
{
    public interface IPostService
    {
        Task<List<PostGetDto>> GetAllByUserAsync(string username, PaginationQuery query);
        Task<List<PostGetDto>> GetAllByLoginUserAsync(PaginationQuery query);

    }
}
