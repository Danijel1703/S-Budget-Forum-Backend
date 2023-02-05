using Forum.Repository.Common.Comment;
using Forum.Repository.Common.Post;
using Forum.Repository.Common.User;

namespace Forum.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        public Task SaveChangesAsync();

        public void SaveChanges();

        public IUserRepository UserRepository { get; set; }
        public IPostRepository PostRepository { get; set; }
        public ICommentRepository CommentRepository { get; set; }
    }
}