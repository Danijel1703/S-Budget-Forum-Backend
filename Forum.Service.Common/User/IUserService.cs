using Forum.Model;
using Forum.Model.Common;
using Forum.Model.Common.Role;
using Forum.Model.Common.User;

namespace Forum.Service.Common.User
{
    public interface IUserService
    {
        public Task RegisterUser(IUserModel user);

        public Task<string> LogInUser(ILoginModel loginModel);

        public Task<IUserModel> GetUserById(Guid id);

        public Task<IEnumerable<IRoleModel>> GetRoles();

        public Task<IPagedResult<IUserModel>> GetUsersPaged(IPaging paging);

        public Task DeleteUser(Guid id);

        public Task UpdateUser(IUserModel user, Guid id);
    }
}