using Forum.Model.Common.Role;
using Forum.Repository.Common.Role;
using Forum.Service.Common.Role;

namespace Forum.Service.Role
{
    public class RoleService : IRoleService
    {
        private IRoleRepository Repository { get; set; }

        public RoleService(IRoleRepository roleRepository)
        {
            Repository = roleRepository;
        }

        public async Task<IEnumerable<IRoleModel>> GetRoles()
        {
            var roles = await Repository.GetAllEntities();
            return roles;
        }
    }
}