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
        private readonly IUserRepositoryRepository _userRepository;
        public UserService(IUserRepositoryRepository userRepository) 
        {
            this._userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _userRepository.GetByPasswordAndEmailAsync(email, password);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
        public async Task<User> CreateUserAsync(User user)
        {
            User createdUser= await _userRepository.AddUserAsync(user);
            return createdUser;
        }

        public async Task CangeUserDataAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user); 
        }
        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

    }
}
