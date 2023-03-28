using Forum.Model.Common.Reaction;
using Forum.Model.Common;
using Forum.Service.Helpers;
using Forum.Repository.Common.Reaction;
using Forum.Repository.Common;
using Forum.Service.Common.Reaction;

namespace Forum.Service.Reaction
{
    public class ReactionService : IReactionService
    {
        private IUnitOfWork unitOfWork { get; set; }
        private IReactionRepository Repository { get; set; }

        public ReactionService(IUnitOfWork _unitOfWork, IReactionRepository reactionRepository)
        {
            unitOfWork = _unitOfWork;
            Repository = reactionRepository;
        }

        public async Task CreateReaction(IReactionModel reaction)
        {
            await unitOfWork.ReactionRepository.Create(reaction);
            unitOfWork.SaveChanges();
        }

        public async Task DeleteReaction(Guid id)
        {
            await unitOfWork.ReactionRepository.Delete(id);
            unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<IReactionModel>> GetReactions(IReactionFilterModel filter, IPaging paging)
        {
            var reactions = await Repository.FindEntities(filter, paging);
            return reactions;
        }
    }
}