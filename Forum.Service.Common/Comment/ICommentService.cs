using Forum.Model.Common.Comment;
using Forum.Model.Common;

namespace Forum.Service.Common.Comment
{
    public interface ICommentService
    {
        public Task CreateComment(ICommentModel comment);

        public Task<IEnumerable<ICommentModel>> GetComments(ICommentFilterModel filter, IPaging paging);

        public Task UpdateComment(ICommentModel comment, Guid id);

        public Task DeleteComment(Guid id);

        public Task<ICommentModel> GetCommentById(Guid id);
    }
}