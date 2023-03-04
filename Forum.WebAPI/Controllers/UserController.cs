using AutoMapper;
using Forum.Model;
using Forum.Model.Common;
using Forum.Model.Common.Role;
using Forum.Model.Common.User;
using Forum.Model.User;
using Forum.Service.Common.User;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Route("/user")]
        public async Task<IPagedResult<IUserModel>> GetUsers([FromQuery] Paging paging)
        {
            try
            {
                var result = await Service.GetUsersPaged(paging);
                return result;
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

        [HttpGet]
        [Route("/user/roles")]
        [Authorize]
        public async Task<IEnumerable<IRoleModel>> GetAllRoles()
        {
            try
            {
                return await Service.GetRoles();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}