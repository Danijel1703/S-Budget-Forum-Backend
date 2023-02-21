namespace Forum.Model.Common.Reaction
{
    public interface IReactionFilterModel
    {
        Guid PostId { get; set; }
        Guid? CommentId { get; set; }
    }
}