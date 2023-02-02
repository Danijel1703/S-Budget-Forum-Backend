using AutoMapper;
using Forum.DAL.Entity;
using Forum.Model;



namespace Forum.Repository
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}