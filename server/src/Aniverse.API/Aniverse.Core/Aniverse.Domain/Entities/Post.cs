using Aniverse.Domain.Entities.Common;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Domain.Entities
{
    public class Post : BaseEntity<Guid>
    {
        public string Content { get; set; }
        public string UserId { get; set; } 
        public bool IsDeleted { get; set; }
        public AppUser User { get; set; }
        public ICollection<HasTag> HasTags { get; set; }
        public ICollection<Like> Likes { get; set; } 
        public ICollection<Share> Shares { get; set; }
    }
}
