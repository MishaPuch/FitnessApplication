using Azure;
using FitnessApp.DAL.Helpers;
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
    public class UserRepository : IUserRepository
    {
        private readonly FitnessAppContext _context;
        private readonly ITreningPlanRepository _treningPlan;
        private readonly QueueHelper _queueHelper;
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public UserRepository(FitnessAppContext context, ITreningPlanRepository treningPlan,QueueHelper queueHelper )
        {
            _context = context;
            _treningPlan = treningPlan;
            _queueHelper = queueHelper;
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                user.DateOFLastPayment = DateTime.Now.Date;
                user.IsEmailConfirmed = false;
                user.Avatar = "";
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                User createdUser = await _context.Users.Include(x=>x.Role).Include(x=>x.TreningPlan).FirstOrDefaultAsync(u => u.UserEmail == user.UserEmail);

                //await _queueHelper.EmailVereficationAsync(user);

                return createdUser;
            }
            catch (Exception ex)
            {
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
                .Include(x => x.Role).Include(x => x.TreningPlan)
                .ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .Include(x => x.Role).Include(x => x.TreningPlan)
                .FirstOrDefaultAsync(u => u.UserEmail == email);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                .Include(x => x.Role).Include(x => x.TreningPlan)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
                User changingUser = new();
                
                changingUser = await _context.Users.FindAsync(user.Id);
                if (changingUser == null)
                {
                    changingUser = await GetUserByEmailAsync(user.UserEmail);
                }

                if (changingUser != null)
                {
                    _context.Users.Update(changingUser);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }


        public async Task<User> GetByPasswordAndEmailAsync(string email, string password)
        {
            var user = await _context.Users
                .Include(x => x.Role).Include(x => x.TreningPlan)
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
