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
using Forum.Service.Helpers;

namespace Forum.Service.Post
{
    public class PostService : IPostService
    {
        private IUnitOfWork unitOfWork { get; set; }
        private IPostRepository PostRepository { get; set; }
        private ICommentRepository CommentRepository { get; set; }
        private IReactionRepository ReactionRepository { get; set; }
        private IFilterFacade FilterFacade { get; set; }

        public PostService(IUnitOfWork _unitOfWork, IPostRepository postRepository, ICommentRepository commentRepository, IReactionRepository reactionRepository, IFilterFacade filterFacade)
        {
            unitOfWork = _unitOfWork;
            PostRepository = postRepository;
            FilterFacade = filterFacade;
            CommentRepository = commentRepository;
            ReactionRepository = reactionRepository;
        }

        public async Task CreatePost(IPostModel post)
        {
            await unitOfWork.PostRepository.Create(post);
            unitOfWork.SaveChanges();
        }

        public async Task<IPostModel> GetPostById(Guid id)
        {
            return await PostRepository.GetById(id);
        }

        public async Task<IEnumerable<IPostModel>> GetPosts(IPostFilterModel postFilter, IPaging paging)
        {
            var filter = FilterFacade.BuildPostFilter(postFilter);
            var posts = await PostRepository.GetEntities(filter, paging);
            return posts;
        }

        public async Task UpdatePost(IPostModel post)
        {
            await unitOfWork.PostRepository.Update(post);
            unitOfWork.SaveChanges();
        }

        public async Task DeletePost(Guid id)
        {
            await unitOfWork.PostRepository.Delete(id);
            unitOfWork.SaveChanges();
        }

        public async Task CreateComment(ICommentModel comment)
        {
            await unitOfWork.CommentRepository.Create(comment);
            unitOfWork.SaveChanges();
        }

        public async Task<ICommentModel> GetCommentById(Guid id)
        {
            return await CommentRepository.GetById(id);
        }

        public async Task<IEnumerable<ICommentModel>> GetComments(ICommentFilterModel commentFilter, IPaging paging)
        {
            var filter = FilterFacade.BuildCommentFilter(commentFilter);
            var posts = await CommentRepository.GetEntities(filter, paging);
            return posts;
        }

        public async Task UpdateComment(ICommentModel comment)
        {
            await unitOfWork.CommentRepository.Update(comment);
            unitOfWork.SaveChanges();
        }

        public async Task DeleteComment(Guid id)
        {
            await unitOfWork.CommentRepository.Delete(id);
            unitOfWork.SaveChanges();
        }

        public async Task CreateReaction(IReactionModel reaction)
        {
            await unitOfWork.ReactionRepository.Create(reaction);
            unitOfWork.SaveChanges();
        }

        public async Task DeleteReaction(Guid id)
        {
            await unitOfWork.ReactionRepository.Delete(id);
            unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<IReactionModel>> GetReactions(IReactionFilterModel reactionFilter, IPaging paging)
        {
            var filter = FilterFacade.BuildReactionFilter(reactionFilter);
            var reactions = await ReactionRepository.GetEntities(filter, paging);
            return reactions;
        }
    }
}