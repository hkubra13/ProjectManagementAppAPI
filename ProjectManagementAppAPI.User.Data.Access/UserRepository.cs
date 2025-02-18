using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.User.Data.Access
{
    public class UserRepository(UserDbContext context) : IUserRepository
    {
        private readonly UserDbContext context = context;

        public async Task<Model.User> CreateAsync(Model.User user)
        {
            context.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id) ?? throw new Exception("User not found");
            context.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Model.User>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<Model.User> GetByIdAsync(int id)
        {
            var user = await context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
            return user == null ? throw new Exception("User not found") : user;
        }

        public async Task<Model.User> UpdateAsync(Model.User user)
        {
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return user;
        }
    }
}
