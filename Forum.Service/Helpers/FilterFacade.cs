using Forum.DAL.Entity;
using Forum.Model;
using Forum.Model.Common;
using Forum.Model.Common.Comment;
using Forum.Model.Common.Post;
using Forum.Model.Common.Reaction;
using Forum.Model.Common.User;
using System.Linq.Expressions;

namespace Forum.Service.Helpers
{
    public class FilterFacade : IFilterFacade
    {
        public IFilter<UserEntity> BuildUserFilter(IUserFilterModel userFilter)
        {
            var expressions = new Expression<Func<UserEntity, bool>>[typeof(IUserFilterModel).GetProperties().Length];
            if (userFilter != null)
            {
                if (userFilter.Username != null)
                {
                    expressions[0] = u => u.Username == userFilter.Username;
                }
                if (userFilter.FirstName != null)
                {
                    expressions[1] = u => u.FirstName == userFilter.FirstName;
                }
                if (userFilter.LastName != null)
                {
                    expressions[2] = u => u.LastName == userFilter.LastName;
                }
                if (userFilter.Email != null)
                {
                    expressions[3] = u => u.Email == userFilter.Email;
                }
                if (userFilter.Id != null)
                {
                    expressions[4] = u => u.Id == userFilter.Id;
                }
            }
            var filter = new Filter<UserEntity>();
            filter.Expressions = expressions.Where(e => e != null);
            return filter;
        }

        public IFilter<PostEntity> BuildPostFilter(IPostFilterModel postFilter)
        {
            var expressions = new Expression<Func<PostEntity, bool>>[typeof(IPostFilterModel).GetProperties().Length];
            if (postFilter != null)
            {
                if (postFilter.UserId != null)
                {
                    expressions[0] = e => e.UserId == postFilter.UserId;
                }
            }
            var filter = new Filter<PostEntity>();
            filter.Expressions = expressions.Where(e => e != null);
            return filter;
        }

        public IFilter<CommentEntity> BuildCommentFilter(ICommentFilterModel commentFilter)
        {
            var expressions = new Expression<Func<CommentEntity, bool>>[typeof(ICommentFilterModel).GetProperties().Length];
            if (commentFilter != null)
            {
                if (commentFilter.UserId != null)
                {
                    expressions[0] = e => e.UserId == commentFilter.UserId;
                }
                if (commentFilter.PostId != null)
                {
                    expressions[0] = e => e.PostId == commentFilter.PostId;
                }
            }
            var filter = new Filter<CommentEntity>();
            filter.Expressions = expressions.Where(e => e != null);
            return filter;
        }

        public IFilter<ReactionEntity> BuildReactionFilter(IReactionFilterModel reactionFilter)
        {
            var expressions = new Expression<Func<ReactionEntity, bool>>[typeof(IReactionFilterModel).GetProperties().Length];
            if (reactionFilter != null)
            {
                if (reactionFilter.CommentId != null)
                {
                    expressions[0] = e => e.CommentId == reactionFilter.CommentId;
                }
                if (reactionFilter.PostId != null)
                {
                    expressions[0] = e => e.PostId == reactionFilter.PostId;
                }
            }
            var filter = new Filter<ReactionEntity>();
            filter.Expressions = expressions.Where(e => e != null);
            return filter;
        }
    }
}