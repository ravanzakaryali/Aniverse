using Aniverse.Domain.Entities.Common;
using Aniverse.Domain.Entities.Common.Enums;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Domain.Entities
{
    public class FriendRequest : BaseEntity<Guid>
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string FriendId { get; set; }
        public AppUser Friend { get; set; }
        public FriendReqeustStatus Status { get; set; }
        public int DeclinedCount { get; set; }
    }
}
