using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAppAPI.User.Data.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectManagementAppAPI.User.Data.Access
{
    public class UserDbContext : DbContext
    {
        public DbSet<Model.Models.User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Model.Models.User>().ToTable("Users");

            modelBuilder.Entity<Model.Models.User>()
                .HasIndex(u => u.UserName).
                IsUnique();
        }
    }
}
