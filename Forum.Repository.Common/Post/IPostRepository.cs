using Forum.DAL.Entity;
using Forum.Model.Common.Post;
using Forum.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Repository.Common.Post
{
    public interface IPostRepository : IGenericRepository<IPostModel, PostEntity>
    {
    }
}
