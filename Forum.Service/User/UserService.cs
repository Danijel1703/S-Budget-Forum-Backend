using Forum.Model;
using Forum.Repository.Common;
using Forum.Service.Helpers;
using Forum.Model.User;
using Forum.Model.Common.User;
using Forum.Repository.Common.User;
using Forum.Service.Common.User;

namespace Forum.Service.User
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
            userModel.RoleId = new Guid("f260c091-e2b4-4dff-be08-88685835514a"); // Remove later
            userModel.DateCreated = DateTime.UtcNow;
            userModel.DateUpdated = DateTime.UtcNow;

            await unitOfWork.UserRepository.Create(userModel);
            unitOfWork.SaveChanges();
        }

        public async Task<bool> LogInUser(ILoginModel userCredentials)
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
                return isValid;
            }
            return false;
        }
    }
}