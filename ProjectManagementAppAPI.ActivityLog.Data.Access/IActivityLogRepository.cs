using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.ActivityLog.Data.Access
{
    public interface IActivityLogRepository
    {
        public Task<IEnumerable<Model.ActivityLog>> GetAllAsync();
        public Task<Model.ActivityLog> GetByIdAsync(int id);
        public Task<IEnumerable<Model.ActivityLog>> GetByTaskIdAsync(int id);
        public Task<IEnumerable<Model.ActivityLog>> GetByUserIdAsync(int id);
        public Task<Model.ActivityLog> CreateAsync(Model.ActivityLog activityLog);
        public Task<Model.ActivityLog> UpdateAsync(Model.ActivityLog activityLog);
        public Task<bool> DeleteAsync(int id);
    }
}
