using Forum.DAL.Entity;
using Forum.Model.Common.Comment;

namespace Forum.Repository.Common.Comment
{
    public interface ICommentRepository : IGenericRepository<ICommentModel, ICommentFilterModel, CommentEntity>
    {
    }
}