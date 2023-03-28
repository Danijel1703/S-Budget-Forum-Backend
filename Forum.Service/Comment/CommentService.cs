using Forum.Model.Common;
using Forum.Model.Common.Comment;
using Forum.Repository.Common;
using Forum.Repository.Common.Comment;
using Forum.Repository.Common.Post;
using Forum.Repository.Common.Reaction;
using Forum.Service.Common.Comment;
using Forum.Service.Helpers;

namespace Forum.Service.Post
{
    public class CommentService : ICommentService
    {
        private IUnitOfWork unitOfWork { get; set; }
        private ICommentRepository Repository { get; set; }

        public CommentService(IUnitOfWork _unitOfWork, ICommentRepository commentRepository)
        {
            unitOfWork = _unitOfWork;
            Repository = commentRepository;
        }

        public async Task CreateComment(ICommentModel comment)
        {
            await unitOfWork.CommentRepository.Create(comment);
            unitOfWork.SaveChanges();
        }

        public async Task<ICommentModel> GetCommentById(Guid id)
        {
            return await Repository.GetById(id);
        }

        public async Task<IEnumerable<ICommentModel>> GetComments(ICommentFilterModel filter, IPaging paging)
        {
            var posts = await Repository.FindEntities(filter, paging);
            return posts;
        }

        public async Task UpdateComment(ICommentModel comment, Guid id)
        {
            await unitOfWork.CommentRepository.Update(comment, id);
            unitOfWork.SaveChanges();
        }

        public async Task DeleteComment(Guid id)
        {
            await unitOfWork.CommentRepository.Delete(id);
            unitOfWork.SaveChanges();
        }
    }
}