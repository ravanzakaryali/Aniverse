using Aniverse.Domain.Entities.Common;
using Aniverse.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aniverse.Domain.Entities
{
    public class AnimalFollow : IBaseEntity<Guid>, ICreatedDate
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Guid AnimalId { get; set; }
        public Animal Animal { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
