using Forum.DAL.Entity;
using Forum.Model.Common.Reaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Repository.Common.Reaction
{
    public interface IReactionRepository : IGenericRepository<IReactionModel, ReactionEntity>
    {
    }
}
