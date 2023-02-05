using AutoMapper;
using Forum.Model;
using Microsoft.AspNetCore.Mvc;
using Forum.Service.Helpers;
using Forum.Model.Comment;
using Forum.Model.Post;
using Forum.Model.Common.Comment;
using Forum.Model.Common.Post;
using Forum.Service.Common.Post;

namespace Forum.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        public IPostService Service { get; set; }
        public IMapper mapper { get; set; }

        public PostController(IPostService service, IMapper _mapper)
        {
            Service = service;
            mapper = _mapper;
        }

        [HttpPost]
        [Route("/post/create")]
        public async Task CreatePost(PostModel post)
        {
            await Service.CreatePost(post);
        }

        [HttpGet]
        [Route("/post/{id}")]
        public async Task<IPostModel> GetPostById(Guid id)
        {
            return await Service.GetPostById(id);
        }

        [HttpGet]
        [Route("/post/")]
        public async Task<IEnumerable<IPostModel>> GetPosts([FromQuery] PostFilterModel filter)
        {
            var paging = new Paging();
            paging.RecordsPerPage = filter.RecordsPerPage;
            paging.Page = filter.Page;
            paging.Skip = filter.Page - 1;
            return await Service.GetPosts(filter, paging);
        }

        [HttpPut]
        [Route("/post/update")]
        public async Task UpdatePost(PostModel postModel)
        {
            await Service.UpdatePost(postModel);
        }

        [HttpDelete]
        [Route("/post/delete")]
        public async Task DeletePost(Guid id)
        {
            await Service.DeletePost(id);
        }

        [HttpPost]
        [Route("/post/comment/create")]
        public async Task CreateComment(CommentModel comment)
        {
            await Service.CreateComment(comment);
        }

        [HttpGet]
        [Route("/post/comment/{id}")]
        public async Task<ICommentModel> GetCommeentById(Guid id)
        {
            return await Service.GetCommentById(id);
        }

        [HttpGet]
        [Route("/post/comment/")]
        public async Task<IEnumerable<ICommentModel>> GetComments([FromQuery] CommentFilterModel filter)
        {
            var paging = new Paging();
            paging.RecordsPerPage = filter.RecordsPerPage;
            paging.Page = filter.Page;
            paging.Skip = filter.Page - 1;
            return await Service.GetComments(filter, paging);
        }

        [HttpPut]
        [Route("/post/comment/update")]
        public async Task UpdateComment(CommentModel commentModel)
        {
            await Service.UpdateComment(commentModel);
        }

        [HttpDelete]
        [Route("/post/comment/delete")]
        public async Task DeleteComment(Guid id)
        {
            await Service.DeleteComment(id);
        }
    }
}
