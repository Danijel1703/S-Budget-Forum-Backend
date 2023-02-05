using Forum.Model.Common.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Comment
{
    public class CommentModel : ICommentModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}
