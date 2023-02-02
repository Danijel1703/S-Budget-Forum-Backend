namespace Forum.Model.Common
{
    public interface IUserModel
    {
        public Guid Id { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; }
        public DateTime DateUpdated { get; }
        public Guid RoleId { get; set; }
    }
}