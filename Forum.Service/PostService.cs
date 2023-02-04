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
        private IPostRepository Repository { get; set; }
        private IFilterFacade FilterFacade { get; set; }

        public PostService(IUnitOfWork _unitOfWork, IPostRepository postRepository, IFilterFacade filterFacade)
        {
            unitOfWork = _unitOfWork;
            Repository = postRepository;
            FilterFacade = filterFacade;
        }

        public async Task CreatePost(IPostModel post) 
        {
            await unitOfWork.PostRepository.Create(post);
            unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<IPostModel>> GetPosts(IPostFilterModel postFilter)
        {
            var filter = FilterFacade.BuildPostFilter(postFilter);
            var posts = await Repository.GetEntities(filter);
            return posts;
        }
        public async Task Update(IPostModel post)
        {
        }
    
        public async Task Delete(IPostModel post)
        {
        }

    }
}
