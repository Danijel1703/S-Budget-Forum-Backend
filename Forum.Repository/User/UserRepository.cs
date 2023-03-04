using AutoMapper;
using Forum.DAL.Entity;
using Forum.Model;
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

        public async Task<IEnumerable<IUserModel>> GetEntities(IFilter<UserEntity>? filter, IPaging paging)
        {
            var query = dbContext.Set<UserEntity>().AsQueryable();
            if (filter != null && filter.Expressions.Any())
            {
                foreach (var expression in filter.Expressions)
                {
                    query = query.Where(expression);
                }
            }
            var entites = query.OrderBy(e => e.DateCreated).Skip(paging.Skip).Take(paging.RecordsPerPage).ToList();
            await Task.FromResult(entites);
            var usersList = mapper.Map<IEnumerable<UserModel>>(entites);
            return usersList;
        }

        public async Task<IPagedResult<IUserModel>> GetUsersPaged(IFilter<UserEntity>? filter, IPaging paging)
        {
            var entities = await GetEntities(filter, paging);
            var totalRecords = dbContext.Set<UserEntity>().Count();
            IPagedResult<IUserModel> pagedResult = ToPagedList<IUserModel>(entities, paging, totalRecords);
            return pagedResult;
        }

        private IPagedResult<TEntityModel> ToPagedList<TEntityModel>(IEnumerable<TEntityModel> entities, IPaging paging, int totalRecords)
        {
            IPagedResult<TEntityModel> pagedResult = new PagedResult<TEntityModel>();
            pagedResult.Item = entities;
            pagedResult.Page = paging.Page;
            pagedResult.TotalRecords = totalRecords;
            pagedResult.RecordsPerPage = paging.RecordsPerPage;
            return pagedResult;
        }
    }
}