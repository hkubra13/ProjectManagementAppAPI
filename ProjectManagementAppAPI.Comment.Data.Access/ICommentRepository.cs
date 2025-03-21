using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Comment.Data.Access
{
    public interface ICommentRepository
    {
        public Task<IEnumerable<Model.Comment>> GetAllAsync();
        public Task<Model.Comment> GetByIdAsync(int id);
        public Task<IEnumerable<Model.Comment>> GetByTaskIdAsync(int id);
        public Task<IEnumerable<Model.Comment>> GetByUserIdAsync(int id);
        public Task<Model.Comment> CreateAsync(Model.Comment comment);
        public Task<Model.Comment> UpdateAsync(Model.Comment comment);
        public Task<bool> DeleteAsync(int id);
    }
}
