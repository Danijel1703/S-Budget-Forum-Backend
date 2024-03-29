﻿namespace Forum.Model.Common.User
{
    public interface IUserFilterModel
    {
        Guid? Id { get; set; }
        string? Username { get; set; }
        string? Email { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
    }
}