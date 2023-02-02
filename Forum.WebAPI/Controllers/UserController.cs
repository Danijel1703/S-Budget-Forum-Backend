using Forum.Model;
using Forum.Service.Common;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public IUserService service { get; set; }
        public UserController(IUserService _service) 
        {
            service= _service;
        }

        [HttpPost]
        [Route("/register")]
        public async void RegisterUser(UserModel user)
        {
            await service.RegisterUser(user);
        }

    }
}
