using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.User.Data.Access
{
    public interface IUserRepository
    {
        public Task<IEnumerable<Model.Models.User>> GetAllAsync();
        public Task<Model.Models.User> GetByIdAsync(int id);
        public Task<Model.Models.User> CreateAsync (Model.Models.User user);
        public Task<Model.Models.User> UpdateAsync (Model.Models.User user);
        public Task<bool> DeleteAsync (int id);
        public Task<Model.Models.User> GetUserNameAsync(string userName);
    }
}
