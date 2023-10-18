using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.InterfaceRepositories;
using FitnessApp.DAL.Models;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.DiRepositories
{
    public class UserRepository : IUserRepositoryRepository
    {
        private readonly FitnessAppContext _context;
        private readonly ITreningPlanRepository _treningPlan;
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public UserRepository(FitnessAppContext context, ITreningPlanRepository treningPlan )
        {
            _context = context;
            _treningPlan = treningPlan;
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                user.DateOFLastPayment = DateTime.Now.Date;
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                User createdUser = await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == user.UserEmail);
                return createdUser;
            }
            catch (Exception ex)
            {
                // Log the inner exception for debugging.
                // You can log it to a file, the console, or another suitable location.
                Logger.Error(ex.InnerException.ToString());
                throw;
            }
        }


        public async Task DeleteUserAsync(int userId)
        {
            _context.Users.Remove(await GetUserByIdAsync(userId));
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserEmail == email);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task UpdateUserAsync(User user)
        {
            User changingUser;
            if (user.Id == 0)
            {
                changingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserEmail == user.UserEmail);
            }
            else
            {
                changingUser = await _context.Users
                    .FirstOrDefaultAsync(u=>u.Id == user.Id);
            }
            changingUser.UserName = user.UserName;
            changingUser.UserEmail = user.UserEmail;
            changingUser.Password = user.Password;
            changingUser.Sex = user.Sex;
            changingUser.Age = user.Age;
            changingUser.RestTime = user.RestTime;
            changingUser.CalorificValue = user.CalorificValue;
            changingUser.RoleId = user.RoleId;

            await _context.SaveChangesAsync();

        }

        public async Task<User> GetByPasswordAndEmailAsync(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserEmail == email && u.Password == password);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
