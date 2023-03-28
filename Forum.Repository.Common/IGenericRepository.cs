using Forum.Model.Common;
using System.Linq.Expressions;

namespace Forum.Repository.Common
{
    public interface IGenericRepository<TResource, TResourceFilter, TEntity>
    {
        public Task Create(TResource resource);

        public Task Update(TResource resource, Guid id);

        public Task Delete(Guid id);

        public Task<IEnumerable<TResource>> FindEntities(TResourceFilter? filter, IPaging paging);

        public Task<TResource> GetById(Guid id);

        public int TotalEntitiesCount();

        public Expression<Func<TEntity, bool>>[] BuildFilter(TResourceFilter? filter);
    }
}