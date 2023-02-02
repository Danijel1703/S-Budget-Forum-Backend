using AutoMapper;
using Forum.Repository.Common;

namespace Forum.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ForumContext dbContext { get; set; }
        public IUserRepository UserRepository { get; set; }
        
        public UnitOfWork(ForumContext context, IUserRepository _userRepository) 
        {
            UserRepository = _userRepository;
            dbContext = context;
        }

        public async Task Commit()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();  
        }
    }
}