using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.DI_Service
{
    public interface IUserService
    {
        public Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
        public Task<List<User>> GetAllUsersAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task<User> CreateUserAsync(User user);
        public Task CangeUserDataAsync(User user);
        public Task<User> GetUserByEmailAsync(string email);
        public Task DeleteUserAsync(int userId);

    }
}
