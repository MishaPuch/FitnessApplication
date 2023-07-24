using FitnessApp.Models;

namespace FitnessApp.DAL.InterfaceRepositories
{
    public interface IExerciseRepository
    {
        public Task<List<Exercise>> GetAllExercisesAsync();
        public Task<Exercise> GetExerciseByIdAsync(int exerciseId);
        public Task CreateExerciseAsync(Exercise exercise);
        public Task UpdateExerciseAsync(Exercise exercise);
        public Task DeleteExerciseByIdAsync(int exerciseId);

    }
}