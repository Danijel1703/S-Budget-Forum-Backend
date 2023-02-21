using AutoMapper;
using Forum.Model.User;
using Forum.Service.Common.User;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Forum.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public IUserService Service { get; set; }
        public IMapper mapper { get; set; }

        public UserController(IUserService service, IMapper _mapper)
        {
            Service = service;
            mapper = _mapper;
        }

        [HttpPost]
        [Route("/user/register")]
        public async Task<HttpResponseMessage> RegisterUser(UserModel resource)
        {
            try
            {
                var user = mapper.Map<UserModel>(resource);
                await Service.RegisterUser(user);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]
        [Route("/user/login")]
        public async Task<string> LogInUser(LoginModel resource)
        {
            try
            {
                var token = await Service.LogInUser(resource);
                return token;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}