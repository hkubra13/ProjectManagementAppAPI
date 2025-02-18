using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Board.Data.Access
{
    public class BoardDbContext : DbContext
    {
        public DbSet<Model.Board> Boards { get; set; }

        public BoardDbContext(DbContextOptions<BoardDbContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
