using Forum.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Repository.Common
{
    public interface IUserRepository
    {
        public Task Create(IUserModel user);
    }
}
