using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Project.Data.Access
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<Model.Project>> GetAllAsync();
        public Task<Model.Project> GetByIdAsync(int id);
        public Task<IEnumerable<Model.Project>> GetByUserIdAsync(int id);
        public Task<Model.Project> CreateAsync(Model.Project project);
        public Task<Model.Project> UpdateAsync(Model.Project project);
        public Task<bool> DeleteAsync(int id);
    }
}
