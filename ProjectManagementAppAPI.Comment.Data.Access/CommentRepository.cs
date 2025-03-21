using Microsoft.EntityFrameworkCore;
using ProjectManagementAppAPI.Board.Data.Access;
using ProjectManagementAppAPI.Task.Data.Access;
using ProjectManagementAppAPI.User.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Comment.Data.Access
{
    public class CommentRepository(CommentDbContext commentDbContext, TaskDbContext taskDbContext, UserDbContext userDbContext) : ICommentRepository
    {
        private readonly CommentDbContext context = commentDbContext;
        private readonly TaskDbContext taskDbContext = taskDbContext;
        private readonly UserDbContext userDbContext = userDbContext;

        public async Task<Model.Comment> CreateAsync(Model.Comment comment)
        {
            context.Add(comment);
            await context.SaveChangesAsync();
            return comment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var comment = await GetByIdAsync(id) ?? throw new Exception("Comment not found");
            context.Remove(comment);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Model.Comment>> GetAllAsync()
        {
            return await context.Comments.ToListAsync();
        }

        public async Task<Model.Comment> GetByIdAsync(int id)
        {
            var comment = await context.Comments.Where(c => c.CommentId == id).FirstOrDefaultAsync();
            return comment ?? throw new Exception("Comment not found");
        }

        public async Task<IEnumerable<Model.Comment>> GetByTaskIdAsync(int id)
        {
            var taskExists = await taskDbContext.Tasks.AnyAsync(t => t.TaskId == id);

            if (!taskExists)
                throw new Exception("Task not found");

            var comments = await context.Comments.ToListAsync();
            return comments.Where(c => c.TaskId == id);
        }

        public async Task<IEnumerable<Model.Comment>> GetByUserIdAsync(int id)
        {
            var userExists = await userDbContext.Users.AnyAsync(u => u.UserId == id);

            if (!userExists)
                throw new Exception("User not found");

            var comments = await context.Comments.ToListAsync();
            return comments.Where(c => c.UserId == id);
        }

        public async Task<Model.Comment> UpdateAsync(Model.Comment comment)
        {
            context.Entry(comment).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return comment;
        }
    }
}
