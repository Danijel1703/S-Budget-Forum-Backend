using AutoMapper;
using Forum.Model.Common;
using Forum.Repository.Common;

namespace Forum.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ForumContext dbContext { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IPostRepository PostRepository { get; set; }


        public UnitOfWork(ForumContext context, IMapper mapper)
        {
            dbContext = context;
            UserRepository = new UserRepository(dbContext, mapper);
            PostRepository= new PostRepository(dbContext, mapper);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}