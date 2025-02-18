using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Comment.Data.Access
{
    public class CommentDbContext : DbContext
    {
        public DbSet<Model.Comment> Comments { get; set; }

        public CommentDbContext(DbContextOptions<CommentDbContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
