using Forum.DAL.Entity;
using Forum.Model.Common;
using Forum.Model.Common.Comment;
using Forum.Model.Common.Post;
using Forum.Model.Common.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Helpers
{
    public interface IFilterFacade
    {
        IFilter<UserEntity> BuildUserFilter(IUserFilterModel userFilter);
        IFilter<PostEntity> BuildPostFilter(IPostFilterModel postFilter);
        IFilter<CommentEntity> BuildCommentFilter(ICommentFilterModel commentFilter);
    }
}
