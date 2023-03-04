namespace Forum.DAL.Entity
{
    public class RoleEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Abrv { get; set; }

        //Navigators
        public List<UserEntity> User { get; set; }
    }
}