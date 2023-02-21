using System.Linq.Expressions;

namespace Forum.Model.Common
{
    public interface IFilter<TEntity>
    {
        public IEnumerable<Expression<Func<TEntity, bool>>> Expressions { get; set; }
    }
}