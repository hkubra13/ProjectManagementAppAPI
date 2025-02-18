using Microsoft.EntityFrameworkCore;
using ProjectManagementAppAPI.Project.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Project.Data.Access
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Model.Project> Projects { get; set; }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
