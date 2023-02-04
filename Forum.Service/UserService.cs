using BCrypt.Net;
using Forum.DAL.Entity;
using Forum.Model;
using Forum.Model.Common;
using Forum.Repository.Common;
using Forum.Service.Common;
using Forum.Service.Helpers;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Forum.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork { get; set; }
        private IUserRepository Repository { get; set; }
        private IFilterFacade FilterFacade { get; set; }

        public UserService(IUnitOfWork _unitOfWork, IUserRepository userRepository, IFilterFacade filterFacade)
        {
            unitOfWork = _unitOfWork;
            Repository = userRepository;
            FilterFacade = filterFacade;
        }

        public async Task RegisterUser(IUserModel userModel)
        {
            userModel.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password);
            userModel.RoleId = new Guid("f61d4973-7193-4e7d-91bd-8e9a6f6813c4"); // Remove later
            userModel.DateCreated = DateTime.UtcNow;
            userModel.DateUpdated = DateTime.UtcNow;

            await unitOfWork.UserRepository.Create(userModel);
            unitOfWork.SaveChanges();
        }

        public async Task<bool> LogInUser(ILoginModel userCredentials)
        {
            var userFilter = new UserFilterModel();
            userFilter.Email= userCredentials.Email;

            var filter = FilterFacade.BuildUserFilter(userFilter);
            var users = await Repository.GetEntities(filter);
            if(users.Any())
            {
                var user = users.First();
                var isValid = BCrypt.Net.BCrypt.Verify(userCredentials.Password, user.Password);
                return isValid;
            }
            return false;
        }
    }
}