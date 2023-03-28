using AutoMapper;
using Forum.DAL.Entity;
using Forum.Model.Common;
using Forum.Model.Common.User;
using Forum.Model.User;
using Forum.Repository.Common.User;
using System.Data.Entity;
using System.Linq.Expressions;

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

        public async Task Update(IUserModel userModel, Guid id)
        {
            UserEntity updatedUserEntity = mapper.Map<UserEntity>(userModel);
            var query = dbContext.Set<UserEntity>();
            var entity = query.AsQueryable().Where(e => e.Id == id).SingleOrDefault();
            if (entity != null)
            {
                entity.Username = updatedUserEntity.Username;
                entity.LastName = updatedUserEntity.LastName;
                entity.FirstName = updatedUserEntity.FirstName;
                entity.Email = updatedUserEntity.Email;
                entity.Password = updatedUserEntity.Password;
                entity.RoleId = updatedUserEntity.RoleId;
                entity.DateUpdated = DateTime.Now;
                query.Update(entity);
            }
            await Task.FromResult(entity);
        }

        public async Task Delete(Guid id)
        {
            var query = dbContext.Set<UserEntity>();
            var entity = query.AsQueryable().SingleOrDefault(e => e.Id == id);
            if (entity != null)
            {
                query.Remove(entity);
            }
            await Task.FromResult(entity);
        }

        public async Task<IUserModel> GetById(Guid id)
        {
            var query = dbContext.Set<UserEntity>().AsQueryable();
            var entity = query.Where(x => x.Id == id).SingleOrDefault();
            await Task.FromResult(entity);
            var user = mapper.Map<UserModel>(entity);
            return user;
        }

        public async Task<IEnumerable<IUserModel>> FindEntities(IUserFilterModel? filter, IPaging paging)
        {
            var query = dbContext.Set<UserEntity>().AsQueryable();
            if (filter != null)
            {
                var filterExpressions = BuildFilter(filter);
                if (filterExpressions != null)
                {
                    foreach (var expression in filterExpressions)
                    {
                        query = query.Where(expression);
                    }
                }
            }
            var entites = query.OrderBy(e => e.DateCreated).Skip(paging.Skip).Take(paging.RecordsPerPage).ToList();
            await Task.FromResult(entites);
            var usersList = mapper.Map<IEnumerable<UserModel>>(entites);
            return usersList;
        }

        public int TotalEntitiesCount()
        {
            return dbContext.Set<UserEntity>().Count();
        }

        public Expression<Func<UserEntity, bool>>[] BuildFilter(IUserFilterModel userFilter)
        {
            var expressions = new Expression<Func<UserEntity, bool>>[typeof(IUserFilterModel).GetProperties().Length];
            if (userFilter != null)
            {
                if (userFilter.Username != null)
                {
                    expressions[0] = u => u.Username == userFilter.Username;
                }
                if (userFilter.FirstName != null)
                {
                    expressions[1] = u => u.FirstName == userFilter.FirstName;
                }
                if (userFilter.LastName != null)
                {
                    expressions[2] = u => u.LastName == userFilter.LastName;
                }
                if (userFilter.Email != null)
                {
                    expressions[3] = u => u.Email == userFilter.Email;
                }
                if (userFilter.Id != null)
                {
                    expressions[4] = u => u.Id == userFilter.Id;
                }
            }

            var filter = expressions.Where(e => e != null);
            if (filter.Any())
            {
                return filter.ToArray();
            }
            return null;
        }
    }
}