using Forum.DAL.Entity;
using Forum.Model.Common.Role;

namespace Forum.Repository.Common.Role
{
    public interface IRoleRepository : IGenericRepository<IRoleModel, IRoleModel, RoleEntity>
    {
        Task<IEnumerable<IRoleModel>> GetAllEntities();
    }
}