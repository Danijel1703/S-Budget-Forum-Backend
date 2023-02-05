using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Common.Reaction
{
    public interface IReactionFilterModel
    {
        Guid PostId { get; set; }
        Guid? CommentId { get; set; }
    }
}
