using Aniverse.Application.DTOs.User;

namespace Aniverse.Application.DTOs.Animal
{
    public class AnimalGetAll
    {
        public string Name { get; set; }
        public string Animalname { get; set; }
        public UserGetAll UserGetDto { get; set; }
    }
}
