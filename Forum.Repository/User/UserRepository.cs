using AutoMapper;
using Forum.DAL.Entity;
using Forum.Model.Common;
using Forum.Model.Common.User;
using Forum.Model.User;
using Forum.Repository.Common.User;
using System.Data.Entity;

namespace Forum.Repository.User
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

        public Task Delete(Guid id)
        {
            return default;
        }

        public Task<IUserModel> GetById(Guid id)
        {
            return default;
        }

        public async Task<IEnumerable<IUserModel>> GetEntities(IFilter<UserEntity> filter, IPaging paging)
        {
            var query = dbContext.Set<UserEntity>().AsQueryable();
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
            var usersList = mapper.Map<IEnumerable<UserModel>>(entites);
            return usersList;
        }
    }
}