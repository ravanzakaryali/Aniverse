using Microsoft.AspNetCore.Identity;

namespace Aniverse.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
