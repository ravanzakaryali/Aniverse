using Aniverse.Domain.Entities.Common;

namespace Aniverse.Domain.Entities
{
    public class File : IBaseEntity<Guid>, ICreatedDate
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Storage { get; set; }
        public string ContainerName { get; set; }
        public string FileName { get; set; }
    }
}
