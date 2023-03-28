using Forum.Model.Common.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Common.Role
{
    public interface IRoleService
    {
        Task<IEnumerable<IRoleModel>> GetRoles();
    }
}