namespace Forum.Model.Common.Post
{
    public interface IPostFilterModel
    {
        Guid? UserId { get; set; }
        int RecordsPerPage { get; set; }
        int Page { get; set; }
    }
}