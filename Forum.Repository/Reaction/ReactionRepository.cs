using AutoMapper;
using Forum.DAL.Entity;
using Forum.Model.Comment;
using Forum.Model.Common;
using Forum.Model.Common.Comment;
using Forum.Model.Common.Reaction;
using Forum.Model.Reaction;
using Forum.Repository.Common.Reaction;


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

        public async Task<IEnumerable<IReactionModel>> GetEntities(IFilter<ReactionEntity> filterModel, IPaging paging)
        {
            var query = dbContext.Set<ReactionEntity>().AsQueryable();
            if(filterModel.Expressions.Any())
            {
                foreach(var expression in filterModel.Expressions)
                {
                    query = query.Where(expression);
                }
            }
            var entites = query.OrderBy(e => e.DateCreated).Skip(paging.Skip).Take(paging.RecordsPerPage).ToList();
            await Task.FromResult(entites);
            var comments = mapper.Map<IEnumerable<ReactionModel>>(entites);
            return comments;
        }

        public async Task Update(IReactionModel reaction)
        {
            await Task.FromResult(1);
        }
    
        public async Task<IReactionModel> GetById(Guid id)
        {
            await Task.FromResult(1);
            return default;
        }
    }
}
