using Forum.DAL.Entity;
using Forum.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Common
{
    public interface ICommentRepository : IGenericRepository<ICommentModel, CommentEntity>
    {
    }
}
