using Aniverse.Domain.Entities.Common;
using Aniverse.Domain.Entities.Common.Enums;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Domain.Entities
{
    public class Like : IEntity<Guid>
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public LikeStatus Status { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}
