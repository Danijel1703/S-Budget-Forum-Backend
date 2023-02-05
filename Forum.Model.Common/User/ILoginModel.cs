using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Common.User
{
    public interface ILoginModel
    {
        string Email { get; set; }
        string Password { get; set; }
    }
}
