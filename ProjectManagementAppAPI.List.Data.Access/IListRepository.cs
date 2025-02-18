using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.List.Data.Access
{
    public interface IListRepository
    {
        public Task<IEnumerable<Model.List>> GetAllAsync();
        public Task<Model.List> GetByIdAsync(int id);
        public Task<IEnumerable<Model.List>> GetByBoardIdAsync(int id);
        public Task<Model.List> CreateAsync(Model.List list);
        public Task<Model.List> UpdateAsync(Model.List list);
        public Task<bool> DeleteAsync(int id);
    }
}
