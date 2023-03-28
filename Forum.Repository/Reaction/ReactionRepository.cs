using AutoMapper;
using Forum.DAL.Entity;
using Forum.Model;
using Forum.Model.Common;
using Forum.Model.Common.Reaction;
using Forum.Model.Reaction;
using Forum.Repository.Common.Reaction;
using System.Linq.Expressions;
using System.Security.Policy;

namespace Forum.Repository.Reaction
{
    public class ReactionRepository : IReactionRepository
    {
        private ForumContext dbContext { get; set; }
        private IMapper mapper;

        public ReactionRepository(ForumContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public async Task Create(IReactionModel comment)
        {
            var entity = mapper.Map<ReactionEntity>(comment);
            dbContext.Set<ReactionEntity>().Add(entity);
            await Task.FromResult(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = dbContext.Set<ReactionEntity>().SingleOrDefault(e => e.Id == id);
            dbContext.Set<ReactionEntity>().Remove(entity);
            await Task.FromResult(entity);
        }

        public async Task<IEnumerable<IReactionModel>> FindEntities(IReactionFilterModel? filter, IPaging paging)
        {
            var query = dbContext.Set<ReactionEntity>().AsQueryable();
            if (filter != null)
            {
                var expressions = BuildFilter(filter);
                foreach (var expression in expressions)
                {
                    query = query.Where(expression);
                }
            }
            var entites = query.OrderBy(e => e.DateCreated).Skip(paging.Skip).Take(paging.RecordsPerPage).ToList();
            await Task.FromResult(entites);
            var comments = mapper.Map<IEnumerable<ReactionModel>>(entites);
            return comments;
        }

        public async Task Update(IReactionModel reaction, Guid id)
        {
            await Task.FromResult(1);
        }

        public async Task<IReactionModel> GetById(Guid id)
        {
            await Task.FromResult(1);
            return default;
        }

        public int TotalEntitiesCount()
        {
            return dbContext.Set<ReactionEntity>().Count();
        }

        public Expression<Func<ReactionEntity, bool>>[] BuildFilter(IReactionFilterModel reactionFilter)
        {
            var expressions = new Expression<Func<ReactionEntity, bool>>[typeof(IReactionFilterModel).GetProperties().Length];
            if (reactionFilter != null)
            {
                if (reactionFilter.CommentId != null)
                {
                    expressions[0] = e => e.CommentId == reactionFilter.CommentId;
                }
                if (reactionFilter.PostId != null)
                {
                    expressions[1] = e => e.PostId == reactionFilter.PostId;
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