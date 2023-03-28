using AutoMapper;
using Forum.DAL.Entity;
using Forum.Model.Common;
using Forum.Model.Common.Role;
using Forum.Model.RoleModel;
using Forum.Repository.Common.Role;
using System.Linq.Expressions;

namespace Forum.Repository.Role
{
    public class RoleRepository : IRoleRepository
    {
        private ForumContext dbContext { get; set; }
        private IMapper mapper;

        public RoleRepository(ForumContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public async Task<IEnumerable<IRoleModel>> FindEntities(IRoleModel? filter, IPaging paging)
        {
            return default;
        }

        public async Task<IEnumerable<IRoleModel>> GetAllEntities()
        {
            var query = dbContext.Set<RoleEntity>().AsEnumerable();
            var entities = query.ToArray();
            await Task.FromResult(entities);
            var roles = mapper.Map<IEnumerable<RoleModel>>(entities);
            return roles;
        }

        public int TotalEntitiesCount()
        {
            return dbContext.Set<RoleEntity>().Count();
        }

        public Task Create(IRoleModel role)
        {
            return default;
        }

        public Task Update(IRoleModel role, Guid id)
        {
            return default;
        }

        public Task Delete(Guid id)
        {
            return default;
        }

        public Task<IRoleModel> GetById(Guid id)
        {
            return default;
        }

        public Expression<Func<RoleEntity, bool>>[] BuildFilter(IRoleModel? filter)
        {
            return default;
        }
    }
}