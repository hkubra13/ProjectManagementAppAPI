using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Task.Data.Access
{
    public class TaskDbContext : DbContext 
    {
        public DbSet<Model.Task> Tasks { get; set; }
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
    : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
