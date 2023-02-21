using Forum.Model.Common.Post;

namespace Forum.Model.Post
{
    public class PostFilterModel : IPostFilterModel
    {
        public Guid? UserId { get; set; }
        public int RecordsPerPage { get; set; }
        public int Page { get; set; }
    }
}