using Aniverse.Domain.Entities.Common;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Domain.Entities
{
    public class UserFollow : IBaseEntity<Guid>, ICreatedDate
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string FollowUserId { get; set; }
        public AppUser FollowUser { get; set; }
    }
}
