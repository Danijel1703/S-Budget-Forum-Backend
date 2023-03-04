using Forum.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Forum
{
    public class ForumContext : DbContext
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<PostEntity> Post { get; set; }
        public DbSet<CommentEntity> Comment { get; set; }
        public DbSet<ReactionEntity> Reaction { get; set; }
        public DbSet<ReactionTypeEntity> ReactionType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=Forum;Username=postgres;Password=1234");
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasOne(e => e.Role).WithMany(e => e.User).HasForeignKey(e => e.RoleId).IsRequired();
            modelBuilder.Entity<PostEntity>()
                .HasOne(e => e.User).WithMany(e => e.Post).HasForeignKey(e => e.UserId).IsRequired();
            modelBuilder.Entity<CommentEntity>()
                .HasOne(e => e.Post).WithMany(e => e.Comment).HasForeignKey(e => e.PostId).IsRequired();
            modelBuilder.Entity<CommentEntity>()
                .HasOne(e => e.User).WithMany(e => e.Comment).HasForeignKey(e => e.UserId).IsRequired();
            modelBuilder.Entity<ReactionEntity>()
                .HasOne(e => e.ReactionType).WithMany(e => e.Reaction).HasForeignKey(e => e.ReactionTypeId).IsRequired();

            var userRoleId = Guid.NewGuid();

            //Initial Data
            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "Admin", Abrv = "admin" },
                new RoleEntity { Id = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "Super Admin", Abrv = "super-admin" },
                new RoleEntity { Id = userRoleId, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "User", Abrv = "user" }
            );
            modelBuilder.Entity<ReactionTypeEntity>().HasData(
                new ReactionTypeEntity { Id = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "Upvote", Abrv = "upvote" },
                new ReactionTypeEntity { Id = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "Downvote", Abrv = "Downvote" }
            );
            for (int i = 0; i < 30; i++)
            {
                modelBuilder.Entity<UserEntity>().HasData(
                    new UserEntity { Id = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, FirstName = $"Danijel - {i}", LastName = $"Jakovac - {i}", Email = $"danijel.jakovac{i}@gmail.com", Username = $"Danijel{i}", RoleId = userRoleId, Password = $"danijel123" }
                );
            }
        }
    }
}