using Aniverse.Application.DTOs.User;

namespace Aniverse.Application.DTOs.Comment
{
    public class CommentGet
    {
        public string Content { get; set; }
        public Guid PostId { get; set; }
        public string UserId { get; set; }
        public UserGetAll User { get; set; }
        public Guid? ReplyCommentsId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
