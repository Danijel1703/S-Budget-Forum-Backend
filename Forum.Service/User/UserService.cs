using Forum.Model;
using Forum.Model.Common;
using Forum.Model.Common.Role;
using Forum.Model.Common.User;
using Forum.Model.User;
using Forum.Repository.Common;
using Forum.Repository.Common.Role;
using Forum.Repository.Common.User;
using Forum.Service.Common.User;
using Forum.Service.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Forum.Service.User
{
    public class UserService : IUserService
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private IUserRepository Repository { get; set; }
        private IRoleRepository RoleRepository { get; set; }
        private IFilterFacade FilterFacade { get; set; }
        private readonly IConfiguration configuration;

        public UserService(IUnitOfWork _unitOfWork, IUserRepository userRepository, IFilterFacade filterFacade, IConfiguration config, IRoleRepository roleRepository)
        {
            UnitOfWork = _unitOfWork;
            Repository = userRepository;
            FilterFacade = filterFacade;
            configuration = config;
            RoleRepository = roleRepository;
        }

        public async Task RegisterUser(IUserModel userModel)
        {
            userModel.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password);
            userModel.DateCreated = DateTime.UtcNow;
            userModel.DateUpdated = DateTime.UtcNow;
            var userRoleId = (await GetRoles()).Single(r => r.Abrv == "user").Id;
            userModel.RoleId = userRoleId;
            await UnitOfWork.UserRepository.Create(userModel);
            UnitOfWork.SaveChanges();
        }

        public async Task<string> LogInUser(ILoginModel userCredentials)
        {
            var userFilter = new UserFilterModel();
            var paging = new Paging();
            userFilter.Email = userCredentials.Email;

            var filter = FilterFacade.BuildUserFilter(userFilter);
            var users = await Repository.GetEntities(filter, paging);
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
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
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
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IEnumerable<IRoleModel>> GetRoles()
        {
            var roles = await RoleRepository.GetAllEntities();
            return roles;
        }

        public async Task<IPagedResult<IUserModel>> GetUsersPaged(IPaging paging)
        {
            var result = await Repository.GetUsersPaged(null, paging);
            return result;
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