using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Common
{
    public interface IFilter<TEntity>
    {
        public IEnumerable<Expression<Func<TEntity, bool>>> Expressions { get; set; }
    }
}
