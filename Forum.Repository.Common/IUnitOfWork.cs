using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Repository;

namespace Forum.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        public Task Commit();
        public IUserRepository UserRepository { get; set; }
    }
}
