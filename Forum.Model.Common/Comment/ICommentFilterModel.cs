namespace Forum.Model.Common.Comment
{
    public interface ICommentFilterModel
    {
        Guid? UserId { get; set; }
        Guid? PostId { get; set; }
    }
}