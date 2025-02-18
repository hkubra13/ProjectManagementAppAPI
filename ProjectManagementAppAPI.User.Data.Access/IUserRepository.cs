using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.User.Data.Access
{
    public interface IUserRepository
    {
        public Task<IEnumerable<Model.User>> GetAllAsync();
        public Task<Model.User> GetByIdAsync(int id);
        public Task<Model.User> CreateAsync (Model.User user);
        public Task<Model.User> UpdateAsync (Model.User user);
        public Task<bool> DeleteAsync (int id);
    }
}
