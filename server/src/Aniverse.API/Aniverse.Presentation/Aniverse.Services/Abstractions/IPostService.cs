using Aniverse.Application.DTOs.Common;
using Aniverse.Application.DTOs.Post;

namespace Aniverse.Services.Abstractions
{
    public interface IPostService
    {
        Task<List<PostGetDto>> GetAllByUser(string username, PaginationQuery query);

    }
}
