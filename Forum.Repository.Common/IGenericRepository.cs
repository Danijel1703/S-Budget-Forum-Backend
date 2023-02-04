using Forum.DAL.Entity;
using Forum.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Repository.Common
{
    public interface IGenericRepository<TResource, TEntity>
    {
        public Task Create(TResource resource);
        public Task Update(TResource resource);
        public Task Delete(TResource resource);
        public Task<IEnumerable<TResource>> GetEntities(IFilter<TEntity> filter);
    }
}
