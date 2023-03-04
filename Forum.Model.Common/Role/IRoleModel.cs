using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Common.Role
{
    public interface IRoleModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
    }
}