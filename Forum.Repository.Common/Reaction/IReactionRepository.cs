using Forum.DAL.Entity;
using Forum.Model.Common.Reaction;

namespace Forum.Repository.Common.Reaction
{
    public interface IReactionRepository : IGenericRepository<IReactionModel, ReactionEntity>
    {
    }
}