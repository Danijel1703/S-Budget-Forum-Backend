using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Common.Post
{
    public interface IPostFilterModel
    {
        Guid? UserId { get; set; }
        int RecordsPerPage { get; set; }
        int Page { get; set; }
    }
}
