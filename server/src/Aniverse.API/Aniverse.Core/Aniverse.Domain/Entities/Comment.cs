using Aniverse.Domain.Entities.Common;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Domain.Entities
{
    public class Comment : BaseEntity<Guid>
    {
        public string Content { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Guid? ReplyCommentsId { get; set; }
        public ICollection<Comment> ReplyComments { get; set; }
    }
}
