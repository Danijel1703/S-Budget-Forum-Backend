using Forum.Model.Common;

namespace Forum.Service.Common
{
    public interface IUserService
    {
        public Task RegisterUser(IUserModel user);
    }
}