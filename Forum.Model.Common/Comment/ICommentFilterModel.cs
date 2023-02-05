using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Common.Comment
{
    public interface ICommentFilterModel
    {
        Guid? UserId { get; set; }
        Guid? PostId { get; set; }
        int RecordsPerPage { get; set; }
        int Page { get; set; }
    }
}
