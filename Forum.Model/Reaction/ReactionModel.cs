using Forum.Model.Common.Reaction;

namespace Forum.Model.Reaction
{
    public class ReactionModel : IReactionModel
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid ReactionTypeId { get; set; }
        public Guid PostId { get; set; }
        public Guid? CommentId { get; set; }
    }
}