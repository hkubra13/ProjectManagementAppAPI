using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Task.Data.Access
{
    public interface ITaskRepository
    {
        public Task<IEnumerable<Model.Task>> GetAllAsync();
        public Task<Model.Task> GetByIdAsync(int id);
        public Task<IEnumerable<Model.Task>> GetByListIdAsync(int id);
        public Task<IEnumerable<Model.Task>> GetByUserIdAsync(int id);
        public Task<Model.Task> CreateAsync(Model.Task task);
        public Task<Model.Task> UpdateAsync(Model.Task task);
        public Task<bool> DeleteAsync(int id);
    }
}
