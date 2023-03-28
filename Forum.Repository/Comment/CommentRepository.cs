using AutoMapper;
using Forum.DAL.Entity;
using Forum.Model;
using Forum.Model.Comment;
using Forum.Model.Common;
using Forum.Model.Common.Comment;
using Forum.Repository.Common.Comment;
using System.Linq.Expressions;

namespace Forum.Repository.Comment
{
    public class CommentRepository : ICommentRepository
    {
        private ForumContext dbContext { get; set; }
        private IMapper mapper;

        public CommentRepository(ForumContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public async Task Create(ICommentModel post)
        {
            CommentEntity postEntity = mapper.Map<CommentEntity>(post);
            dbContext.Set<CommentEntity>().Add(postEntity);
            await Task.FromResult(postEntity);
        }

        public async Task<IEnumerable<ICommentModel>> FindEntities(ICommentFilterModel? filter, IPaging paging)
        {
            var query = dbContext.Set<CommentEntity>().AsQueryable();
            if (filter != null)
            {
                var expresions = BuildFilter(filter);
                foreach (var expression in expresions)
                {
                    query = query.Where(expression);
                }
            }
            var entites = query.OrderBy(e => e.DateCreated).Skip(paging.Skip).Take(paging.RecordsPerPage).ToList();
            await Task.FromResult(entites);
            var postsList = mapper.Map<IEnumerable<CommentModel>>(entites);
            return postsList;
        }

        public async Task Update(ICommentModel post, Guid id)
        {
            var existingPost = dbContext.Set<CommentEntity>().SingleOrDefault(e => e.Id == id);
            if (existingPost != null)
            {
                existingPost.Content = post.Content;
                existingPost.DateUpdated = DateTime.UtcNow;
            }
            await Task.FromResult(existingPost);
        }

        public async Task Delete(Guid id)
        {
            var entity = dbContext.Set<CommentEntity>().SingleOrDefault(e => e.Id == id);
            if (entity != null)
            {
                dbContext.Set<CommentEntity>().Remove(entity);
            }
            await Task.FromResult(entity);
        }

        public async Task<ICommentModel> GetById(Guid id)
        {
            var entity = dbContext.Set<CommentEntity>().SingleOrDefault(e => e.Id == id);
            await Task.FromResult(entity);
            var post = mapper.Map<CommentModel>(entity);
            return post;
        }

        public int TotalEntitiesCount()
        {
            return dbContext.Set<CommentEntity>().Count();
        }

        public Expression<Func<CommentEntity, bool>>[] BuildFilter(ICommentFilterModel commentFilter)
        {
            var expressions = new Expression<Func<CommentEntity, bool>>[typeof(ICommentFilterModel).GetProperties().Length];
            if (commentFilter != null)
            {
                if (commentFilter.UserId != null)
                {
                    expressions[0] = e => e.UserId == commentFilter.UserId;
                }
                if (commentFilter.PostId != null)
                {
                    expressions[1] = e => e.PostId == commentFilter.PostId;
                }
            }

            var filter = expressions.Where(e => e != null);
            if (filter.Any())
            {
                return filter.ToArray();
            }
            return default;
        }
    }
}