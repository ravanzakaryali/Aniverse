using Aniverse.Domain.Entities.Common.Enums;
using Microsoft.AspNetCore.Identity;

namespace Aniverse.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsDeleted { get; set; }
        public string? Bio { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime RegisterDate { get; set; }
        public ICollection<FriendRequest> FriendRequests { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Share> Shares { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Animal> Animals { get; set; }
        public ICollection<SavePost> SavePosts { get; set; }
    }
}
