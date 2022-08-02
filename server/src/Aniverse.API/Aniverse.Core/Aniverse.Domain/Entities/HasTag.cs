using Aniverse.Domain.Entities.Common;

namespace Aniverse.Domain.Entities
{
    public class HasTag : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
