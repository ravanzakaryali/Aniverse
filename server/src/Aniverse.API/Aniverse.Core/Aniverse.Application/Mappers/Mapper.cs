using Aniverse.Application.DTOs.Animal;
using Aniverse.Application.DTOs.HasTag;
using Aniverse.Application.DTOs.Post;
using Aniverse.Application.DTOs.User;
using Aniverse.Domain.Entities;
using Aniverse.Domain.Entities.Identity;
using AutoMapper;

namespace Aniverse.Application.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            #region User
            CreateMap<AppUser, UserGetDto>();
            CreateMap<AppUser, UserGetAll>();
            #endregion
            #region Animal
            CreateMap<Animal, AnimalGetDto>();
            CreateMap<Animal, AnimalGetAll>();
            CreateMap<AnimalCreateDto, Animal>();
            #endregion
            #region HasTag
            CreateMap<HasTag, HasTagGet>();
            #endregion
            #region Post
            CreateMap<Post, PostGetWithAnimalDto>();
            CreateMap<Post, PostGetDto>();
            CreateMap<PostCreate, Post>();
            #endregion
        }
    }
}
