using Forum.Model.Common;
using Forum.Model.Common.Comment;
using Forum.Model.Common.Post;
using Forum.Model.Common.Reaction;

namespace Forum.Service.Common.Post
{
    public interface IPostService
    {
        public Task CreatePost(IPostModel post);

        public Task<IEnumerable<IPostModel>> GetPosts(IPostFilterModel filter, IPaging paging);

        public Task UpdatePost(IPostModel post, Guid id);

        public Task DeletePost(Guid id);

        public Task<IPostModel> GetPostById(Guid id);

        public Task CreateComment(ICommentModel comment);

        public Task<IEnumerable<ICommentModel>> GetComments(ICommentFilterModel filter, IPaging paging);

        public Task UpdateComment(ICommentModel comment, Guid id);

        public Task DeleteComment(Guid id);

        public Task<ICommentModel> GetCommentById(Guid id);

        public Task<IEnumerable<IReactionModel>> GetReactions(IReactionFilterModel filter, IPaging paging);

        public Task CreateReaction(IReactionModel comment);

        public Task DeleteReaction(Guid id);
    }
}