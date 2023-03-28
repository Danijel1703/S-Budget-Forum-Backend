using Forum.Model.Common;
using Forum.Model.Common.Comment;
using Forum.Model.Common.Post;
using Forum.Model.Common.Reaction;

namespace Forum.Service.Common.Post
{
    public interface IPostService
    {
        public Task CreatePost(IPostModel post);

        public Task<IEnumerable<IPostModel>> FindPosts(IPostFilterModel filter, IPaging paging);

        public Task UpdatePost(IPostModel post, Guid id);

        public Task DeletePost(Guid id);

        public Task<IPostModel> GetPostById(Guid id);
    }
}