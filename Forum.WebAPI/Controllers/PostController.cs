using AutoMapper;
using Forum.Model;
using Forum.Model.Common;
using Forum.Service.Common;
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
        [Route("/create")]
        public async Task CreatePost(PostModel post)
        {
            await Service.CreatePost(post);
        }

        [HttpGet]
        [Route("/")]
        public async Task<IEnumerable<IPostModel>> GetPosts([FromQuery] PostFilterModel filter)
        {
            return await Service.GetPosts(filter);
        }
    }
}
