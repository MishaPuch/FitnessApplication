using FitnessApp.Models;

namespace FitnessApp.DAL.InterfaceRepositories
{
    public interface IUserRepository
    {
        public Task<User> GetByPasswordAndEmailAsync(string email,string password);
        public Task<List<User>> GetAllUsersAsync();
        public Task<User> GetUserByIdAsync(int userId);
        public Task<User> GetUserByEmailAsync(string email);
        public Task AddUserAsync(User user); 
        public Task UpdateUserAsync(User user);
        public Task DeleteUserAsync(int userId);

    }
}