using Forum.DAL.Entity;
using Forum.Model.Common;
using Forum.Model.Common.Comment;
using Forum.Model.Common.Post;
using Forum.Model.Common.Reaction;
using Forum.Model.Common.User;

namespace Forum.Service.Helpers
{
    public interface IFilterFacade
    {
        IFilter<UserEntity> BuildUserFilter(IUserFilterModel userFilter);

        IFilter<PostEntity> BuildPostFilter(IPostFilterModel postFilter);

        IFilter<CommentEntity> BuildCommentFilter(ICommentFilterModel commentFilter);

        IFilter<ReactionEntity> BuildReactionFilter(IReactionFilterModel reactionFilter);
    }
}