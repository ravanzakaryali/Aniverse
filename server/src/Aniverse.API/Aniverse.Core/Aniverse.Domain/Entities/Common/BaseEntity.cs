namespace Aniverse.Domain.Entities.Common
{
    public class BaseEntity<T> : IBaseEntity<T>, ICreatedDate, IUpdatedDate
    {
        public T Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
    }
}
