using AutoMapper;
using Forum.Model;
using Forum.Model.Comment;
using Forum.Model.Common.Comment;
using Forum.Model.Common.Post;
using Forum.Model.Common.Reaction;
using Forum.Model.Post;
using Forum.Model.Reaction;
using Forum.Service.Common.Comment;
using Forum.Service.Common.Post;
using Forum.Service.Common.Reaction;
using Forum.Service.Common.Role;
using Forum.Service.Reaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        public IPostService Service { get; set; }
        public ICommentService CommentService { get; set; }
        public IReactionService ReactionService { get; set; }
        public IMapper mapper { get; set; }

        public PostController(IPostService service, ICommentService commentService, IReactionService reactionService, IMapper _mapper)
        {
            Service = service;
            CommentService = commentService;
            ReactionService = reactionService;
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

        [HttpPost]
        [Route("/post")]
        public async Task<IEnumerable<IPostModel>> FindPosts([FromBody] PostParams postParams)
        {
            return await Service.FindPosts(postParams.Filter, postParams.Paging);
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
            await CommentService.CreateComment(comment);
        }

        [HttpGet]
        [Route("/post/comment/{id}")]
        public async Task<ICommentModel> GetCommeentById(Guid id)
        {
            return await CommentService.GetCommentById(id);
        }

        [HttpGet]
        [Route("/post/comment")]
        public async Task<IEnumerable<ICommentModel>> GetComments([FromQuery] CommentFilterModel filter, Paging paging)
        {
            return await CommentService.GetComments(filter, paging);
        }

        [HttpPut]
        [Route("/post/comment/{id}/update")]
        [Authorize]
        public async Task UpdateComment(Guid id, CommentModel commentModel)
        {
            await CommentService.UpdateComment(commentModel, id);
        }

        [HttpDelete]
        [Route("/post/comment/delete")]
        [Authorize]
        public async Task DeleteComment(Guid id)
        {
            await CommentService.DeleteComment(id);
        }

        [HttpPost]
        [Route("/post/reaction/create")]
        [Authorize]
        public async Task CreateReaction(ReactionModel reaction)
        {
            await ReactionService.CreateReaction(reaction);
        }

        [HttpGet]
        [Route("/post/reaction")]
        public async Task<IEnumerable<IReactionModel>> GetReactions([FromQuery] ReactionFilterModel filter, Paging paging)
        {
            return await ReactionService.GetReactions(filter, paging);
        }

        [HttpDelete]
        [Route("/post/reaction/delete")]
        [Authorize]
        public async Task DeleteReaction(Guid id)
        {
            await ReactionService.DeleteReaction(id);
        }

        public class PostParams
        {
            public PostFilterModel Filter { get; set; }
            public Paging Paging { get; set; }
        }
    }
}