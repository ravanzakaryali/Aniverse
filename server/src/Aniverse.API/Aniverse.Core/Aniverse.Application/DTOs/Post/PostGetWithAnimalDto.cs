﻿using Aniverse.Application.DTOs.Animal;
using Aniverse.Application.DTOs.HasTag;
using Aniverse.Application.DTOs.User;

namespace Aniverse.Application.DTOs.Post
{
    public class PostGetWithAnimalDto
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public UserGetAll User { get; set; }
        public AnimalGetAll Animal { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int ShareCount { get; set; }
        public List<HasTagGet> HasTags { get; set; }
    }
}
