using Aniverse.Application.DTOs.Common;
using Aniverse.Application.DTOs.User;

namespace Aniverse.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserGetDto> GetAsync(string username);
        Task<List<UserGetAll>> GetAllAsync(PaginationQuery query);
        Task<UserGetDto> GetLoginAsync();
        Task FollowAsync(string username);
    }
}
