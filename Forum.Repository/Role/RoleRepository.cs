using AutoMapper;
using Forum.DAL.Entity;
using Forum.Model;
using Forum.Model.Common;
using Forum.Model.Common.Role;
using Forum.Model.Common.User;
using Forum.Model.RoleModel;
using Forum.Repository.Common.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<IRoleModel>> GetEntities(IFilter<RoleEntity>? filter, IPaging paging)
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
    }
}