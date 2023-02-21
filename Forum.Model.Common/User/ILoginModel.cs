namespace Forum.Model.Common.User
{
    public interface ILoginModel
    {
        string Email { get; set; }
        string Password { get; set; }
    }
}