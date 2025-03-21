using Microsoft.EntityFrameworkCore;
using ProjectManagementAppAPI.Board.Data.Model;
using ProjectManagementAppAPI.Comment.Data.Model;
using ProjectManagementAppAPI.Project.Data.Model;
using ProjectManagementAppAPI.User.Data.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Data.Access
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User.Data.Model.Models.User> Users { get; set; }
        public DbSet<Task.Data.Model.Task> Tasks { get; set; }
        public DbSet<Project.Data.Model.Project> Projects { get; set; }
        public DbSet<List.Data.Model.List> Lists { get; set; }
        public DbSet<Comment.Data.Model.Comment> Comments { get; set; }
        public DbSet<Board.Data.Model.Board> Boards { get; set; }
        public DbSet<Attachment.Data.Model.Attachment> Attachments { get; set; }
        public DbSet<ActivityLog.Data.Model.ActivityLog> ActivityLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project.Data.Model.Project>()
                .HasOne<User.Data.Model.Models.User>()
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Board.Data.Model.Board>()
                .HasOne<Project.Data.Model.Project>()
                .WithMany()
                .HasForeignKey(b => b.ProjectId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<List.Data.Model.List>()
                .HasOne<Board.Data.Model.Board>()
                .WithMany()
                .HasForeignKey(l => l.BoardId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Task.Data.Model.Task>()
                .HasOne<List.Data.Model.List>()
                .WithMany()
                .HasForeignKey(t => t.ListId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Task.Data.Model.Task>()
                .HasOne<User.Data.Model.Models.User>()
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Comment.Data.Model.Comment>()
                .HasOne<Task.Data.Model.Task>()
                .WithMany()
                .HasForeignKey(c => c.TaskId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Comment.Data.Model.Comment>()
                .HasOne<User.Data.Model.Models.User>()
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Attachment.Data.Model.Attachment>()
                .HasOne<Task.Data.Model.Task>()
                .WithMany()
                .HasForeignKey(a => a.TaskId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ActivityLog.Data.Model.ActivityLog>()
                .HasOne<User.Data.Model.Models.User>()
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ActivityLog.Data.Model.ActivityLog>()
                .HasOne<Task.Data.Model.Task>()
                .WithMany()
                .HasForeignKey(a => a.TaskId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
