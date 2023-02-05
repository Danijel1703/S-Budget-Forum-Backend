using Forum.Model.Common.User;

namespace Forum.Service.Common.User
{
    public interface IUserService
    {
        public Task RegisterUser(IUserModel user);

        public Task<bool> LogInUser(ILoginModel loginModel);
    }
}