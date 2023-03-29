using Forum.Model.Common.Role;

namespace Forum.Model.Common.User
{
    public interface IUserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid RoleId { get; set; }
        public IRoleModel Role { get; set; }
    }
}