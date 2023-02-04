using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Common
{
    public interface IPostFilterModel
    {
        Guid? Id { get; set; }
        Guid? UserId { get; set; }
    }
}
