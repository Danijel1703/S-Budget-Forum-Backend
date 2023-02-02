using Forum.Model.Common;
using Forum.Repository.Common;
using Forum.Service.Common;

namespace Forum.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork { get; set; }
        public UserService(IUnitOfWork _unitOfWork) 
        {
            unitOfWork= _unitOfWork;
        }
        public async Task RegisterUser(IUserModel userModel)
        {
            await unitOfWork.UserRepository.Create(userModel);
            await unitOfWork.Commit();
        }
    }
}