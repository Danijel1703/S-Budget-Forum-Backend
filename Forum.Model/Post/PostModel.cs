using Forum.DAL.Entity;
using Forum.Model.Common.Post;

namespace Forum.Model.Post
{
    public class PostModel : IPostModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid UserId { get; set; }
    }
}