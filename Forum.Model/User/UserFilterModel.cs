using Forum.DAL.Entity;
using Forum.Model.Common.User;

namespace Forum.Model.User
{
    public class UserFilterModel : IUserFilterModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}