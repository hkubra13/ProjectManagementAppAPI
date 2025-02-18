using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Board.Data.Access
{
    public interface IBoardRepository
    {
        public Task<IEnumerable<Model.Board>> GetAllAsync();
        public Task<Model.Board> GetByIdAsync(int id);
        public Task<IEnumerable<Model.Board>> GetByProjectIdAsync(int id);
        public Task<Model.Board> CreateAsync(Model.Board board);
        public Task<Model.Board> UpdateAsync(Model.Board board);
        public Task<bool> DeleteAsync(int id);
    }
}
