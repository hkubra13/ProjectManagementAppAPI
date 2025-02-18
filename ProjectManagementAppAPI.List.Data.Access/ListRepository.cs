using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.List.Data.Access
{
    public class ListRepository(ListDbContext listDbContext) : IListRepository
    {
        private readonly ListDbContext context = listDbContext;
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
            var list = await context.Lists.Where(b => b.BoardId == id).ToListAsync();
            return list ?? throw new Exception("List not found");
        }

        public async Task<Model.List> GetByIdAsync(int id)
        {
            var list = await context.Lists.Where(b => b.ListId == id).FirstOrDefaultAsync();
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
