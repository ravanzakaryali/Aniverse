namespace Aniverse.Domain.Entities.Common
{
    public class BaseEntity<TKey> : IBaseEntity<TKey>, ICreatedDate, IUpdatedDate
    {
        public TKey Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
    }
}
