using Forum.Model.Common;

namespace Forum.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        public Task SaveChangesAsync();

        public void SaveChanges();

        public IUserRepository UserRepository { get; set; }
        public IPostRepository PostRepository { get; set; }

    }
}