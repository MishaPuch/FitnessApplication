using FitnessApp.DAL.InterfaceRepositories;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FitnessAppContext _context;
        public UserRepository(FitnessAppContext _context) 
        { 
            this._context = _context;
        }
        
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            _context.Users.Remove(await GetUserByIdAsync(userId));
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync(); 
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == email);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task UpdateUserAsync(User user)
        {
            var changingUser = await _context.Users.FindAsync(user.Id);
            changingUser = user;
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByPasswordAndEmailAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u=>u.UserEmail==email && u.Password==password);
        }
    }
}
