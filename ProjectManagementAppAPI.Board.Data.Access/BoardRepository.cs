using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Board.Data.Access
{
    public class BoardRepository(BoardDbContext boardDbContext) : IBoardRepository
    {
        private readonly BoardDbContext context = boardDbContext;

        public async Task<Model.Board> CreateAsync(Model.Board board)
        {
            context.Add(board);
            await context.SaveChangesAsync();
            return board;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var board = await GetByIdAsync(id) ?? throw new Exception("Board not found");
            context.Remove(board);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Model.Board>> GetAllAsync()
        {
            return await context.Boards.ToListAsync();
        }

        public async Task<Model.Board> GetByIdAsync(int id)
        {
            var board = await context.Boards.Where(b => b.BoardId == id).FirstOrDefaultAsync();
            return board ?? throw new Exception("Board not found");
        }

        public async Task<IEnumerable<Model.Board>> GetByProjectIdAsync(int id)
        {
            var board = await context.Boards.Where(b => b.ProjectId == id).ToListAsync();
            return board ?? throw new Exception("Board not found");
        }

        public async Task<Model.Board> UpdateAsync(Model.Board board)
        {
            context.Entry(board).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return board;
        }
    }
}
