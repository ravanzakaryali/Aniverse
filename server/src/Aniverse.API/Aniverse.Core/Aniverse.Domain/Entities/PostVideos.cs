namespace Aniverse.Domain.Entities
{
    public class PostVideos : File
    {
        public int Lenght { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
