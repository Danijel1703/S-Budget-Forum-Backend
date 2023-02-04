using AutoMapper;
using Forum.DAL.Entity;
using Forum.Model;
using Forum.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Repository
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

        public async Task<IEnumerable<IPostModel>> GetEntities(IFilter<PostEntity> filter)
        {
            var entites = dbContext.Set<PostEntity>().AsQueryable();
            var expresions = filter.Expressions;
            foreach (var expression in expresions)
            {
                entites = entites.Where(expression);
            }
            entites.ToList();
            var postsList = mapper.Map<IEnumerable<PostModel>>(entites);
            await Task.FromResult(entites);
            return postsList;
        }

        public Task Update(IPostModel post)
        {
            return default;
        }

        public Task Delete(IPostModel post)
        {
            return default;
        }
    }
}
