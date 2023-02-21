using Forum.Model.Common;
using System.Linq.Expressions;

namespace Forum.Model
{
    public class Filter<TEntity> : IFilter<TEntity>
    {
        public IEnumerable<Expression<Func<TEntity, bool>>> Expressions { get; set; }
    }
}