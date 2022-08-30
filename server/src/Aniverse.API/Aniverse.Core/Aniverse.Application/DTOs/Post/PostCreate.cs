using Microsoft.AspNetCore.Http;

namespace Aniverse.Application.DTOs.Post
{
    public class PostCreate
    {
        public string Content { get; set; }
        public string AnimalId { get; set; }
        public IFormFileCollection ImageFiles { get; set; }
    }
}
