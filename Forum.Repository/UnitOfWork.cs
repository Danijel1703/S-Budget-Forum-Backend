using AutoMapper;
using Forum.Repository.Common;
using Forum.Repository.Common.Comment;
using Forum.Repository.Common.Post;
using Forum.Repository.Common.User;
using Forum.Repository.User;
using Forum.Repository.Post;
using Forum.Repository.Comment;
using Forum.Repository.Reaction;
using Forum.Repository.Common.Reaction;

namespace Forum.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ForumContext dbContext { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IPostRepository PostRepository { get; set; }
        public ICommentRepository CommentRepository { get; set; }
        public IReactionRepository ReactionRepository { get; set; }


        public UnitOfWork(ForumContext context, IMapper mapper)
        {
            dbContext = context;
            UserRepository = new UserRepository(dbContext, mapper);
            PostRepository= new PostRepository(dbContext, mapper);
            CommentRepository= new CommentRepository(dbContext, mapper);
            ReactionRepository = new ReactionRepository(dbContext, mapper);
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