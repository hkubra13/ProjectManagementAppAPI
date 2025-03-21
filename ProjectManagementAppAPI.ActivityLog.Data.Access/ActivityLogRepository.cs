using Microsoft.EntityFrameworkCore;
using ProjectManagementAppAPI.Task.Data.Access;
using ProjectManagementAppAPI.User.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.ActivityLog.Data.Access
{
    public class ActivityLogRepository(ActivityLogDbContext activityLogDbContext, UserDbContext userDbContext, TaskDbContext taskDbContext) : IActivityLogRepository
    {
        private readonly ActivityLogDbContext context = activityLogDbContext;
        private readonly UserDbContext userDbContext = userDbContext;
        private readonly TaskDbContext taskDbContext = taskDbContext;

        public async Task<Model.ActivityLog> CreateAsync(Model.ActivityLog activityLog)
        {
            context.Add(activityLog);
            await context.SaveChangesAsync();
            return activityLog;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var activityLog = await GetByIdAsync(id) ?? throw new Exception("Activity Log not found");
            context.Remove(activityLog);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Model.ActivityLog>> GetAllAsync()
        {
            return await context.ActivityLogs.ToListAsync();
        }

        public async Task<Model.ActivityLog> GetByIdAsync(int id)
        {
            var activtyLog = await context.ActivityLogs.Where(c => c.ActivityLogId == id).FirstOrDefaultAsync();
            return activtyLog ?? throw new Exception("Activity Log not found");
        }

        public async Task<IEnumerable<Model.ActivityLog>> GetByTaskIdAsync(int id)
        {
            var taskExists = await taskDbContext.Tasks.AnyAsync(t => t.TaskId == id);

            if (!taskExists)
                throw new Exception("Task not found");

            var activityLogs = await context.ActivityLogs.ToListAsync();
            return activityLogs.Where(a => a.TaskId == id);
        }

        public async Task<IEnumerable<Model.ActivityLog>> GetByUserIdAsync(int id)
        {
            var userExists = await userDbContext.Users.AnyAsync(u => u.UserId == id);

            if (!userExists)
                throw new Exception("User not found");

            var activityLogs = await context.ActivityLogs.ToListAsync();
            return activityLogs.Where(a => a.UserId == id);
        }

        public async Task<Model.ActivityLog> UpdateAsync(Model.ActivityLog activityLog)
        {
            context.Entry(activityLog).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return activityLog;
        }
    }
}
