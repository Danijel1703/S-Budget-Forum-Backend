using Forum.Model;
using Forum.Model.Common;
using Forum.Model.Common.Role;
using Forum.Model.Common.User;
using Forum.Model.User;
using Forum.Repository.Common;
using Forum.Repository.Common.Role;
using Forum.Repository.Common.User;
using Forum.Service.Common.Role;
using Forum.Service.Common.User;
using Forum.Service.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Forum.Service.User
{
    public class UserService : IUserService
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private IUserRepository Repository { get; set; }
        private IRoleService RoleService { get; set; }
        private readonly IConfiguration configuration;

        public UserService(IUnitOfWork _unitOfWork, IUserRepository userRepository, IConfiguration config, IRoleService roleService)
        {
            UnitOfWork = _unitOfWork;
            Repository = userRepository;
            configuration = config;
            RoleService = roleService;
        }

        public async Task RegisterUser(IUserModel userModel)
        {
            userModel.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password);
            userModel.DateCreated = DateTime.UtcNow;
            userModel.DateUpdated = DateTime.UtcNow;
            var userRoleId = (await RoleService.GetRoles()).Single(r => r.Abrv == "user").Id;
            userModel.RoleId = userRoleId;
            await UnitOfWork.UserRepository.Create(userModel);
            UnitOfWork.SaveChanges();
        }

        public async Task<string> LogInUser(ILoginModel userCredentials)
        {
            var filter = new UserFilterModel();
            var paging = new Paging();
            filter.Email = userCredentials.Email;
            var users = await Repository.FindEntities(filter, paging);
            if (users.Any())
            {
                var user = users.First();
                var isValid = BCrypt.Net.BCrypt.Verify(userCredentials.Password, user.Password);
                if (isValid)
                {
                    return GenerateToken(user);
                }
                else
                {
                    return "Invalid password.";
                }
            }
            return "User does not exist.";
        }

        private string GenerateToken(IUserModel userModel)
        {
            var secretKey = Environment.GetEnvironmentVariable("SECRET");
            var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userModel.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, userModel.RoleId.ToString()),
            };
            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.WriteToken(token);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IPagedResult<IUserModel>> FindUsers(IPaging paging)
        {
            var result = await Repository.FindEntities(null, paging);
            var pagedResult = PagedListHelper<IUserModel>.ToPagedList(result, paging, Repository.TotalEntitiesCount());
            return pagedResult;
        }

        public async Task<IUserModel> GetUserById(Guid id)
        {
            var result = await Repository.GetById(id);
            return result;
        }

        public async Task DeleteUser(Guid id)
        {
            await UnitOfWork.UserRepository.Delete(id);
            UnitOfWork.SaveChanges();
        }

        public async Task UpdateUser(IUserModel userModel, Guid id)
        {
            await UnitOfWork.UserRepository.Update(userModel, id);
            UnitOfWork.SaveChanges();
        }
    }
}