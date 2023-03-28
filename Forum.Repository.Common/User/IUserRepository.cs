using Forum.DAL.Entity;
using Forum.Model;
using Forum.Model.Common;
using Forum.Model.Common.User;

namespace Forum.Repository.Common.User
{
    public interface IUserRepository : IGenericRepository<IUserModel, IUserFilterModel, UserEntity>
    {
    }
}