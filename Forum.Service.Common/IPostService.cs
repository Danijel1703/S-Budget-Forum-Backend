using Forum.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Common
{
    public interface IPostService
    {
        Task CreatePost(IPostModel post);
        public Task<IEnumerable<IPostModel>> GetPosts(IPostFilterModel filter);
    }
}
