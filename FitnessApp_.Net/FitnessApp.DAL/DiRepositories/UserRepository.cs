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
    public class UserRepository : IUserRepositoryRepository
    {
        private readonly FitnessAppContext _context;
        public UserRepository(FitnessAppContext context) 
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            user.DateOFLastPayment = DateTime.Now.Date;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            User? createdUser = _context.Users.FirstOrDefault(u => u.UserEmail == user.UserEmail);
            return createdUser;

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
            var changingUser = await _context.Users.FirstOrDefaultAsync(u=>u.UserEmail==user.UserEmail);
            
            changingUser.UserName = user.UserName;
            changingUser.Password = user.Password;
            changingUser.Age = user.Age;
            changingUser.RestTime = user.RestTime;
            changingUser.CalorificValue = user.CalorificValue;

            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByPasswordAndEmailAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == email && u.Password == password);
            if (user != null)
                return user;
            else
                return null;
        }
    }
}
