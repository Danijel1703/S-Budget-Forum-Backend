using Forum.DAL.Entity;
using Forum.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model
{
    public class Filter<TEntity> : IFilter<TEntity>
    {
        public IEnumerable<Expression<Func<TEntity, bool>>> Expressions { get; set; }
    }
}
