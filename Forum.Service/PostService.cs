using Forum.DAL.Entity;
using Forum.Model.Common;
using Forum.Repository.Common;
using Forum.Service.Common;
using Forum.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service
{
    public class PostService : IPostService
    {
        private IUnitOfWork unitOfWork { get; set; }
        private IPostRepository PostRepository { get; set; }
        private ICommentRepository CommentRepository { get; set; }
        private IFilterFacade FilterFacade { get; set; }

        public PostService(IUnitOfWork _unitOfWork, IPostRepository postRepository,ICommentRepository commentRepository , IFilterFacade filterFacade)
        {
            unitOfWork = _unitOfWork;
            PostRepository = postRepository;
            FilterFacade = filterFacade;
            CommentRepository = commentRepository;
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

    }
}
