using AutoMapper;
using Forum.Model;
using Forum.Model.Comment;
using Forum.Model.Common.Comment;
using Forum.Model.Common.Post;
using Forum.Model.Common.Reaction;
using Forum.Model.Post;
using Forum.Model.Reaction;
using Forum.Service.Common.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [Authorize]
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
        [Route("/post")]
        public async Task<IEnumerable<IPostModel>> GetPosts([FromQuery] PostFilterModel filter, Paging paging)
        {
            return await Service.GetPosts(filter, paging);
        }

        [HttpPut]
        [Route("/post/{id}/update")]
        [Authorize]
        public async Task UpdatePost(PostModel postModel, Guid id)
        {
            await Service.UpdatePost(postModel, id);
        }

        [HttpDelete]
        [Route("/post/{id}/delete")]
        [Authorize]
        public async Task DeletePost(Guid id)
        {
            await Service.DeletePost(id);
        }

        [HttpPost]
        [Route("/post/comment/create")]
        [Authorize]
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
        [Route("/post/comment")]
        public async Task<IEnumerable<ICommentModel>> GetComments([FromQuery] CommentFilterModel filter, Paging paging)
        {
            return await Service.GetComments(filter, paging);
        }

        [HttpPut]
        [Route("/post/comment/{id}/update")]
        [Authorize]
        public async Task UpdateComment(Guid id, CommentModel commentModel)
        {
            await Service.UpdateComment(commentModel, id);
        }

        [HttpDelete]
        [Route("/post/comment/delete")]
        [Authorize]
        public async Task DeleteComment(Guid id)
        {
            await Service.DeleteComment(id);
        }

        [HttpPost]
        [Route("/post/reaction/create")]
        [Authorize]
        public async Task CreateReaction(ReactionModel reaction)
        {
            await Service.CreateReaction(reaction);
        }

        [HttpGet]
        [Route("/post/reaction")]
        public async Task<IEnumerable<IReactionModel>> GetReactions([FromQuery] ReactionFilterModel filter, Paging paging)
        {
            return await Service.GetReactions(filter, paging);
        }

        [HttpDelete]
        [Route("/post/reaction/delete")]
        [Authorize]
        public async Task DeleteReaction(Guid id)
        {
            await Service.DeleteReaction(id);
        }
    }
}