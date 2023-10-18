using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Interface
{
    public interface IExerciseService
    {
        public Task<Exercise> GetExerciseByIdAsync(int ExerciseId);
        public Task<List<Exercise>> GetAllExercisesAsync();
        public Task CreateExerciseAsync(Exercise exercise);
        public Task<Exercise> UpdateExerciseAsync(Exercise exercise);
        public Task DeleteExerciseAsync(int ExerciseId);

    }
}
