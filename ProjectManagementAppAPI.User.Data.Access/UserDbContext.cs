using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementAppAPI.User.Data.Model;


namespace ProjectManagementAppAPI.User.Data.Access
{
    public class UserDbContext : DbContext
    {
        public DbSet<Model.User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
