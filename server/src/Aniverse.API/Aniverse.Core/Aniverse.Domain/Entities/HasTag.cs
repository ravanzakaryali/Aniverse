using Aniverse.Domain.Entities.Common;

namespace Aniverse.Domain.Entities
{
    public class HasTag : IEntity<Guid>
    {
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
