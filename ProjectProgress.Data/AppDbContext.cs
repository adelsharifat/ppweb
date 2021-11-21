using Microsoft.EntityFrameworkCore;
using ProjectProgress.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using static ProjectProgress.Utils.AppHelpers;

namespace ProjectProgress.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>()
                .HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<UserRole>().HasOne<AppUser>(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<UserRole>().HasOne<AppRole>(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);
            modelBuilder.Entity<AppUser>().HasMany(x => x.RefreshTokens).WithOne(x => x.User).HasForeignKey(x => x.CreatedBy);
            modelBuilder.Entity<AppUser>().HasMany(x => x.Attachments).WithOne(x => x.User).HasForeignKey(x => x.CreatedBy);
            modelBuilder.Entity<Item>().HasMany(x => x.Attachments).WithOne(x => x.Item).HasForeignKey(x => x.ObjectId);
            modelBuilder.Entity<Item>().HasMany(x => x.Items).WithOne(x => x.GetItem).HasForeignKey(x => x.ParentId);
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole { Id = 1, Name = "admin" },
                new AppRole { Id = 2, Name = "user" }
            );

            var salt = BCrypt.GenerateSalt(70);
            modelBuilder.Entity<AppUser>().HasData(
               new AppUser { Id = 1, UserName = "admin", Password = BCrypt.HashPassword("admin", salt, 1010, 70), CreatedDate = DateTime.Now, Salt = salt }
            );

            modelBuilder.Entity<UserRole>().HasData(
               new UserRole { UserId = 1, RoleId = 1 },
               new UserRole { UserId = 1, RoleId = 2 }
            );
        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<AppRole> AppRole { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
    }
}
