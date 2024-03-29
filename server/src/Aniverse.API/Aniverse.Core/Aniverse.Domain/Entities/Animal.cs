﻿using Aniverse.Domain.Entities.Common;
using Aniverse.Domain.Entities.Identity;

namespace Aniverse.Domain.Entities
{
    public class Animal : BaseEntity<Guid>
    {
        public string NormalizedAnimalname { get; set; }
        public string Animalname { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<AnimalFollow> AnimalFollows { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
