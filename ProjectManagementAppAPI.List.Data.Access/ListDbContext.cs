using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.List.Data.Access
{
    public class ListDbContext : DbContext 
    {
        public DbSet<Model.List> Lists { get; set; }

        public ListDbContext(DbContextOptions<ListDbContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
