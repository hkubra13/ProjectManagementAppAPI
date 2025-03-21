using Microsoft.EntityFrameworkCore;
using ProjectManagementAppAPI.List.Data.Access;
using ProjectManagementAppAPI.User.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Task.Data.Access
{
    public class TaskRepository(TaskDbContext taskDbContext, UserDbContext userDbContext, ListDbContext listDbContext) : ITaskRepository
    {
        private readonly TaskDbContext context = taskDbContext;
        private readonly UserDbContext userDbContext = userDbContext;
        private readonly ListDbContext listDbContext = listDbContext;

        public async Task<Model.Task> CreateAsync(Model.Task task)
        {
            context.Add(task);
            await context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await GetByIdAsync(id) ?? throw new Exception("Task not found");
            context.Remove(task);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Model.Task>> GetAllAsync()
        {
            return await context.Tasks.ToListAsync();
        }

        public async Task<Model.Task> GetByIdAsync(int id)
        {
            var task = await context.Tasks.Where(t => t.TaskId == id).FirstOrDefaultAsync();
            return task ?? throw new Exception("Task not found");
        }

        public async Task<IEnumerable<Model.Task>> GetByListIdAsync(int id)
        {
            var listExists = await listDbContext.Lists.AnyAsync(l => l.ListId == id);

            if (!listExists)
                throw new Exception("List not found");

            var tasks = await context.Tasks.ToListAsync();
            return tasks.Where(t => t.ListId == id);
        }

        public async Task<IEnumerable<Model.Task>> GetByUserIdAsync(int id)
        {
            var userExists = await userDbContext.Users.AnyAsync(u => u.UserId == id);

            if (!userExists)
                throw new Exception("User not found");

            var tasks = await context.Tasks.ToListAsync();
            return tasks.Where(t => t.UserId == id);
        }

        public async Task<Model.Task> UpdateAsync(Model.Task task)
        {
            context.Entry(task).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return task;
        }
    }
}
