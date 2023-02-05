using Forum.Model.Common;
using Forum.Model.Common.Comment;
using Forum.Model.Common.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Common.Post
{
    public interface IPostService
    {
        public Task CreatePost(IPostModel post);
        public Task<IEnumerable<IPostModel>> GetPosts(IPostFilterModel filter, IPaging paging);
        public Task UpdatePost(IPostModel post);
        public Task DeletePost(Guid id);
        public Task<IPostModel> GetPostById(Guid id);
        public Task CreateComment(ICommentModel comment);
        public Task<IEnumerable<ICommentModel>> GetComments(ICommentFilterModel filter, IPaging paging);
        public Task UpdateComment(ICommentModel comment);
        public Task DeleteComment(Guid id);
        public Task<ICommentModel> GetCommentById(Guid id);
    }
}
