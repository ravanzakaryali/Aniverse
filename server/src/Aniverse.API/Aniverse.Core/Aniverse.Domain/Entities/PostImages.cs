namespace Aniverse.Domain.Entities
{
    public class PostImages : File
    {
        public ICollection<Post> Posts { get; set; }
    }
}
