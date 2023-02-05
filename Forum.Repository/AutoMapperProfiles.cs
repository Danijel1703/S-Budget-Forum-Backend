using AutoMapper;
using Forum.DAL.Entity;
using Forum.Model.Post;
using Forum.Model.User;

namespace Forum.Repository
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<PostEntity, PostModel>().ReverseMap();
        }
    }
}