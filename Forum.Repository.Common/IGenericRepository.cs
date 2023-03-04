using Forum.Model.Common;

namespace Forum.Repository.Common
{
    public interface IGenericRepository<TResource, TEntity>
    {
        public Task Create(TResource resource);

        public Task Update(TResource resource);

        public Task Delete(Guid id);

        public Task<IEnumerable<TResource>> GetEntities(IFilter<TEntity> filter, IPaging paging);

        public Task<TResource> GetById(Guid id);
    }
}