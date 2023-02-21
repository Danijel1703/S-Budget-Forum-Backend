using Forum.DAL.Entity;
using Forum.Model.Common.User;

namespace Forum.Repository.Common.User
{
    public interface IUserRepository : IGenericRepository<IUserModel, UserEntity>
    {
    }
}