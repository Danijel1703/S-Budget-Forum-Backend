using Forum.Model.Common.Reaction;

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