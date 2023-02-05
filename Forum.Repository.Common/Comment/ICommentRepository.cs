using Forum.DAL.Entity;
using Forum.Model.Common.Comment;
using Forum.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Repository.Common.Comment
{
    public interface ICommentRepository : IGenericRepository<ICommentModel, CommentEntity>
    {
    }
}
