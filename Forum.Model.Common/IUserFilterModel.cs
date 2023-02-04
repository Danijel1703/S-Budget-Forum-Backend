using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Common
{
    public interface IUserFilterModel
    {
        Guid? Id { get; set; }
        string? Username { get; set; }
        string? Email { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
    }
}
