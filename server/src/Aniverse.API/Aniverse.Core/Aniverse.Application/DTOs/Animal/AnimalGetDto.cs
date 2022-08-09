using Aniverse.Application.DTOs.User;

namespace Aniverse.Application.DTOs.Animal
{
    public class AnimalGetDto
    {
        public string Name { get; set; }
        public string Animalname { get; set; }
        public string Bio { get; set; }
        public UserGetAll UserGetDto { get; set; }
    }
}
