namespace Aniverse.Domain.Entities.Common
{
    public interface IBaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
