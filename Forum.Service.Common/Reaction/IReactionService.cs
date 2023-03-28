using Forum.Model.Common.Reaction;
using Forum.Model.Common;

namespace Forum.Service.Common.Reaction
{
    public interface IReactionService
    {
        public Task<IEnumerable<IReactionModel>> GetReactions(IReactionFilterModel filter, IPaging paging);

        public Task CreateReaction(IReactionModel comment);

        public Task DeleteReaction(Guid id);
    }
}