using Microsoft.AspNetCore.Identity;
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
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        private readonly IPasswordHasher<Data.Model.Models.User> _passwordHasher;

        public UserRepository(UserDbContext context, IPasswordHasher<Data.Model.Models.User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<Model.Models.User> CreateAsync(Model.Models.User user)
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, user.PasswordHash);

            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id) ?? throw new Exception("User not found");
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Model.Models.User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Model.Models.User> GetByIdAsync(int id)
        {
            var user = await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
            return user == null ? throw new Exception("User not found") : user;
        }

        public async Task<Model.Models.User> GetUserNameAsync(string userName)
        {
            var user = await _context.Users
                .Where(u => u.UserName == userName)
                .FirstOrDefaultAsync();
            return user == null ? throw new Exception("User not found") : user;
        }

        public async Task<Model.Models.User> UpdateAsync(Model.Models.User user)
        {
            var existingUser = await GetByIdAsync(user.UserId) ?? throw new Exception("User not found");

            if (!string.IsNullOrEmpty(user.PasswordHash) && user.PasswordHash != existingUser.PasswordHash)
                existingUser.PasswordHash = _passwordHasher.HashPassword(existingUser, user.PasswordHash);

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.UserName = user.UserName;
            existingUser.Role = user.Role;

            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}
