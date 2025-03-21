using Microsoft.EntityFrameworkCore;
using ProjectManagementAppAPI.Board.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.List.Data.Access
{
    public class ListRepository(ListDbContext listDbContext, BoardDbContext boardDbContext) : IListRepository
    {
        private readonly ListDbContext context = listDbContext;
        private readonly BoardDbContext boardDbContext = boardDbContext;
        public async Task<Model.List> CreateAsync(Model.List list)
        {
            context.Add(list);
            await context.SaveChangesAsync();
            return list;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var list = await GetByIdAsync(id) ?? throw new Exception("List not found");
            context.Remove(list);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Model.List>> GetAllAsync()
        {
            return await context.Lists.ToListAsync();
        }

        public async Task<IEnumerable<Model.List>> GetByBoardIdAsync(int id)
        {
            var boardExists = await boardDbContext.Boards.AnyAsync(b => b.BoardId == id);

            if (!boardExists)
                throw new Exception("Board not found");

            var lists = await context.Lists.ToListAsync();
            return lists.Where(l => l.BoardId == id);
        }

        public async Task<Model.List> GetByIdAsync(int id)
        {
            var list = await context.Lists.Where(l => l.ListId == id).FirstOrDefaultAsync();
            return list ?? throw new Exception("List not found");
        }

        public async Task<Model.List> UpdateAsync(Model.List list)
        {
            context.Entry(list).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return list;
        }
    }
}
