using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Model;

namespace Forum.Model.Common
{
    public interface IPostFilterModel
    {
        Guid? UserId { get; set; }
        int RecordsPerPage { get; set; }
        int Page { get; set; }
    }
}
