using Forum.Model.Common.User;

namespace Forum.Model.User
{
    public class LoginModel : ILoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}