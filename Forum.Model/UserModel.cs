﻿using Forum.Model.Common;

namespace Forum.Model
{
    public class UserModel : IUserModel
    {
        public Guid Id { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid RoleId { get; set; }
    }
}