using Forum.DAL.Entity;
using Forum.Model.Common.User;
using System.Linq.Expressions;

namespace Forum.Repository.Common.User
{
    public interface IUserRepository : IGenericRepository<IUserModel, UserEntity>
    {
    }
}