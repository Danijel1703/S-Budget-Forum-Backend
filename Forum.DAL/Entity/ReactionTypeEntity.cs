namespace Forum.DAL.Entity
{
    public class ReactionTypeEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        //Navigators
        public List<ReactionEntity> Reaction { get; set; }
    }
}