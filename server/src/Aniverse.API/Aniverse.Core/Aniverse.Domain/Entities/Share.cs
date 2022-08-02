using Aniverse.Domain.Entities.Common;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Domain.Entities
{
    public class Share : BaseEntity<Guid>
    {
        public string PostUrl { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; } 
    }
}
