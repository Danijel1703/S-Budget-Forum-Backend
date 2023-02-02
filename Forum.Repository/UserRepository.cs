using AutoMapper;
using Forum.DAL.Entity;
using Forum.Model.Common;
using Forum.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class UserRepository : IUserRepository
    {
        private ForumContext dbContext { get; set; }
        private IMapper mapper;
        public UserRepository(ForumContext _dbContext, IMapper _mapper) 
        {
            dbContext = _dbContext;
            mapper= _mapper;
        }

        public async Task Create(IUserModel user)
        {
            user.RoleId = new Guid("f61d4973-7193-4e7d-91bd-8e9a6f6813c4");
            UserEntity userEntity = mapper.Map<UserEntity>(user);
            dbContext.Set<UserEntity>().Add(userEntity);
            await Task.FromResult(userEntity);
        }
    }
}
