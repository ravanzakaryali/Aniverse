namespace Aniverse.Domain.Entities.Common
{
    public class IEntity<Tkey> : ICreatedDate, IUpdatedDate
    {
        public Tkey Id { get; set; }
        public virtual DateTime CreatedDate { get; set ; }
        public virtual DateTime UpdatedDate { get; set; }
    }
}
