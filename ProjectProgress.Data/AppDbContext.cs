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

            modelBuilder.Entity<AppUser>().HasMany(x => x.RefreshTokens).WithOne(x => x.User).HasForeignKey(x => x.CreatedBy);
            modelBuilder.Entity<AppUser>().HasMany(x => x.Attachments).WithOne(x => x.User).HasForeignKey(x => x.CreatedBy);
            modelBuilder.Entity<Item>().HasMany(x => x.Attachments).WithOne(x => x.Item).HasForeignKey(x => x.ObjectId);
            modelBuilder.Entity<Item>().HasMany(x => x.Items).WithOne(x => x.GetItem).HasForeignKey(x => x.ParentId);

            modelBuilder.Entity<AppUser>().HasData(
               new AppUser { Id = 1, UserName = "admin", Password = BCrypt.Hash("admin"), CreatedDate = DateTime.Now }
            );
        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
    }
}
