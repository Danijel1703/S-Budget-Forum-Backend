using Forum.Model.Common.Reaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Reaction
{
    public class ReactionFilterModel : IReactionFilterModel
    {
        public Guid PostId { get; set; }
        public Guid? CommentId { get; set; }
        public int RecordsPerPage { get; set; }
        public int Page { get; set; }
    }
}
