using Forum.Model;
using Forum.Model.Common;
using Forum.Model.Common.Comment;
using Forum.Model.Common.Post;
using Forum.Model.Common.Reaction;
using Forum.Repository.Common;
using Forum.Repository.Common.Comment;
using Forum.Repository.Common.Post;
using Forum.Repository.Common.Reaction;
using Forum.Service.Common.Post;

namespace Forum.Service.Post
{
    public class PostService : IPostService
    {
        private IUnitOfWork unitOfWork { get; set; }
        private IPostRepository PostRepository { get; set; }

        public PostService(IUnitOfWork _unitOfWork, IPostRepository postRepository, ICommentRepository commentRepository, IReactionRepository reactionRepository)
        {
            unitOfWork = _unitOfWork;
            PostRepository = postRepository;
        }

        public async Task CreatePost(IPostModel post)
        {
            await unitOfWork.PostRepository.Create(post);
            unitOfWork.SaveChanges();
        }

        public async Task<IPostModel> GetPostById(Guid id)
        {
            var post = await PostRepository.GetById(id);
            return post;
        }

        public async Task<IEnumerable<IPostModel>> FindPosts(IPostFilterModel filter, IPaging paging)
        {
            var posts = await PostRepository.FindEntities(filter, paging);
            return posts;
        }

        public async Task UpdatePost(IPostModel post, Guid id)
        {
            await unitOfWork.PostRepository.Update(post, id);
            unitOfWork.SaveChanges();
        }

        public async Task DeletePost(Guid id)
        {
            await unitOfWork.PostRepository.Delete(id);
            unitOfWork.SaveChanges();
        }
    }
}