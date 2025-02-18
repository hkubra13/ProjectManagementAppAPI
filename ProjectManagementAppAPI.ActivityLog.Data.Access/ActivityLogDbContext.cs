using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.ActivityLog.Data.Access
{
    public class ActivityLogDbContext : DbContext
    {
        public DbSet<Model.ActivityLog> ActivityLogs { get; set; }

        public ActivityLogDbContext(DbContextOptions<ActivityLogDbContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
