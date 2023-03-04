using Forum.Model.Common.Post;

namespace Forum.Model.Post
{
    public class PostFilterModel : IPostFilterModel
    {
        public Guid? UserId { get; set; }
    }
}