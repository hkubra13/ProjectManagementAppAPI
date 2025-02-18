using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Attachment.Data.Access
{
    public class AttachmentDbContext : DbContext
    {
        public DbSet<Model.Attachment> Attachments { get; set; }

        public AttachmentDbContext(DbContextOptions<AttachmentDbContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
