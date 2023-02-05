using Forum.Model.Common.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Comment
{
    public class CommentFilterModel : ICommentFilterModel
    {
        public Guid? PostId { get; set; }
        public Guid? UserId { get; set; }
        public int RecordsPerPage { get; set; }
        public int Page { get; set; }
    }
}
