using AutoMapper;
using Forum.DAL.Entity;
using Forum.Model;
using Forum.Model.Common;
using Forum.Repository.Common;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Forum.Repository
{
    public class UserRepository : IUserRepository
    {
        private ForumContext dbContext { get; set; }
        private IMapper mapper;

        public UserRepository(ForumContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public async Task Create(IUserModel user)
        {
            UserEntity userEntity = mapper.Map<UserEntity>(user);
            dbContext.Set<UserEntity>().Add(userEntity);
            await Task.FromResult(userEntity);
        }

        public Task Update(IUserModel userModel)
        {
            return default;
        }

        public Task Delete(IUserModel userModel)
        {
            return default;
        }

        public async Task<IEnumerable<IUserModel>> GetEntities(IFilter<UserEntity> filter)
        {
            var entites = dbContext.Set<UserEntity>().AsQueryable();
            var expresions = filter.Expressions;
            if(expresions.Any())
            {
                foreach (var expression in expresions)
                {
                    entites = entites.Where(expression);
                }
            }
            entites.ToList();
            var usersList = mapper.Map<IEnumerable<UserModel>>(entites);
            await Task.FromResult(entites);
            return usersList;
        }
    }
}