namespace Aniverse.Domain.Entities.Common
{
    public class BaseEntity<T> : IBaseEntity<T>, ICreatedDate, IUpdatedDate
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
