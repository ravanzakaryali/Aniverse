using Aniverse.Domain.Entities.Common;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Domain.Entities
{
    public class Comment : BaseEntity<string>
    {
        public string Content { get; set; }
        public string PostId { get; set; }
        public Post Post { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string? ReplyCommentsId { get; set; }
        public ICollection<Comment> ReplyComments { get; set; }
    }
}
