using Forum.DAL.Entity;
using Forum.Model.Common;
using System.Linq.Expressions;

namespace Forum.Repository.Common
{
    public interface IUserRepository : IGenericRepository<IUserModel, UserEntity>
    {
    }
}