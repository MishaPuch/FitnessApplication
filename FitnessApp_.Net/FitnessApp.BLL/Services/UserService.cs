using FitnessApp.BLL.DI_Service;
using FitnessApp.DAL.InterfaceRepositories;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository) 
        {
            this.userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await userRepository.GetByPasswordAndEmailAsync(email, password);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await userRepository.GetUserByIdAsync(id);
        }
        public async Task CreateUserAsync(User user)
        {
            await userRepository.AddUserAsync(user);
        }

        public async Task CangeUserDataAsync(User user)
        {
            await userRepository.UpdateUserAsync(user); 
        }
        public async Task DeleteUserAsync(int userId)
        {
            await userRepository.DeleteUserAsync(userId);
        }

    }
}
