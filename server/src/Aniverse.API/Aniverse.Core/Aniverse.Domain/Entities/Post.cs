using Aniverse.Domain.Entities.Common;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Domain.Entities
{
    public class Post : IEntity<Guid>
    {
        public string Content { get; set; }
        public string UserId { get; set; } 
        public AppUser User { get; set; }
        public ICollection<HasTag> HasTags { get; set; }
        public ICollection<Like> Likes { get; set; } 
    }
}
