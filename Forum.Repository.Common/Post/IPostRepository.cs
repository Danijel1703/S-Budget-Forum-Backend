using Forum.DAL.Entity;
using Forum.Model.Common.Post;

namespace Forum.Repository.Common.Post
{
    public interface IPostRepository : IGenericRepository<IPostModel, IPostFilterModel, PostEntity>
    {
    }
}