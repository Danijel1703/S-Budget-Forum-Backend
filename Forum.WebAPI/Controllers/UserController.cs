﻿using AutoMapper;
using Forum.Model;
using Forum.Service.Common;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;

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
        [Route("/register")]
        public async void RegisterUser(UserModel resource)
        {
            var user = mapper.Map<UserModel>(resource);
            await Service.RegisterUser(user);
        }

        [HttpPost]
        [Route("/login")]
        public async void LogInUser(LoginModel resource)
        {
            await Service.LogInUser(resource);
        }
    }
}