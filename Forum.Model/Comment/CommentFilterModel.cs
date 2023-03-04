using Forum.Model.Common.Comment;

namespace Forum.Model.Comment
{
    public class CommentFilterModel : ICommentFilterModel
    {
        public Guid? PostId { get; set; }
        public Guid? UserId { get; set; }
    }
}