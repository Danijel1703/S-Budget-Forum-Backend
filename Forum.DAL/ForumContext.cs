using Forum.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Forum
{
    public class ForumContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
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
                new RoleEntity { Id = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "admin" },
                new RoleEntity { Id = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "super-admin" },
                new RoleEntity { Id = userRoleId, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "user" }
            );
            modelBuilder.Entity<ReactionTypeEntity>().HasData(
                new ReactionTypeEntity { Id = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "upvote" },
                new ReactionTypeEntity { Id = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "downvote" }
            );

            // Seed Data
            for (int i = 0; i < 50; i++)
            {
                var user = new UserEntity();
                var userId = Guid.NewGuid();
                user.Id = userId;
                user.RoleId = userRoleId;
                user.FirstName = $"Danijel {i}";
                user.LastName = $"Jakovac {i}";
                user.Password = $"fake pass";
                user.Email = $"danijel.jakovac{i}@gmail.com";
                user.Username = $"user-{i}";
                user.DateCreated = DateTime.UtcNow;
                user.DateUpdated = DateTime.UtcNow;
                modelBuilder.Entity<UserEntity>().HasData(user);
                for (int j = 0; j < 100; j++)
                {
                    modelBuilder.Entity<PostEntity>().HasData(new PostEntity { Id = Guid.NewGuid(), Content = $"Contet {j}", Title = $"Title {j}", Upvotes = 50, Downvotes = 85, UserId = userId, DateCreated = DateTime.Now, DateUpdated = DateTime.Now });
                }
            }
        }
    }
}