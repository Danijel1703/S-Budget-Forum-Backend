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

            // Initial Data
            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "admin" },
                new RoleEntity { Id = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "super-admin" },
                new RoleEntity { Id = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "user" }
            );
            modelBuilder.Entity<ReactionTypeEntity>().HasData(
                new ReactionTypeEntity { Id = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "upvote" },
                new ReactionTypeEntity { Id = Guid.NewGuid(), DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow, Name = "downvote" }
            );
        }
    }
}