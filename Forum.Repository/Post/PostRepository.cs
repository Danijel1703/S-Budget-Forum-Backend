using AutoMapper;
using Forum.DAL.Entity;
using Forum.Model.Common;
using Forum.Model.Common.Post;
using Forum.Model.Post;
using Forum.Repository.Common.Post;

namespace Forum.Repository.Post
{
    public class PostRepository : IPostRepository
    {
        private ForumContext dbContext { get; set; }
        private IMapper mapper;

        public PostRepository(ForumContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public async Task Create(IPostModel post)
        {
            PostEntity postEntity = mapper.Map<PostEntity>(post);
            dbContext.Set<PostEntity>().Add(postEntity);
            await Task.FromResult(postEntity);
        }

        public async Task<IEnumerable<IPostModel>> GetEntities(IFilter<PostEntity> filter, IPaging paging)
        {
            var query = dbContext.Set<PostEntity>().AsQueryable();
            var expresions = filter.Expressions;
            if (expresions.Any())
            {
                foreach (var expression in expresions)
                {
                    query = query.Where(expression);
                }
            }
            var entites = query.OrderBy(e => e.DateCreated).Skip(paging.Skip).Take(paging.RecordsPerPage).ToList();
            await Task.FromResult(entites);
            var postsList = mapper.Map<IEnumerable<PostModel>>(entites);
            return postsList;
        }

        public async Task Update(IPostModel post)
        {
            var existingPost = dbContext.Set<PostEntity>().SingleOrDefault(e => e.Id == post.Id);
            if (existingPost != null)
            {
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
                existingPost.DateUpdated = DateTime.UtcNow;
            }
            await Task.FromResult(existingPost);
        }

        public async Task Delete(Guid id)
        {
            var entity = dbContext.Set<PostEntity>().SingleOrDefault(e => e.Id == id);
            if (entity != null)
            {
                dbContext.Set<PostEntity>().Remove(entity);
            }
            await Task.FromResult(entity);
        }

        public async Task<IPostModel> GetById(Guid id)
        {
            var entity = dbContext.Set<PostEntity>().SingleOrDefault(e => e.Id == id);
            await Task.FromResult(entity);
            var post = mapper.Map<PostModel>(entity);
            return post;
        }
    }
}