using FitnessApp.Models;

namespace FitnessApp.DAL.InterfaceRepositories
{
    public interface IDietRepository
    {
        public Task<List<Diet>> GetAllDietAsync();
        public Task<Diet> GetDietByIdAsync(int dietId);
        public Task<Diet> GetDietByCalorifieAsync(int dietCalorifie);
        public Task CreateDietAsync(Diet diet);
        public Task UpdateDietAsync(Diet diet);
        public Task DeleteDietByIdAsync(int dietId);
        

    }
}