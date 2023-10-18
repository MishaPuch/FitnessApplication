using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Interface
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        public ExerciseService(IExerciseRepository exerciseRepository) 
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task CreateExerciseAsync(Exercise exercise)
        {
            await _exerciseRepository.CreateExerciseAsync(exercise);
        }

        public async Task DeleteExerciseAsync(int ExerciseId)
        {
            await _exerciseRepository.DeleteExerciseAsync(ExerciseId);
        }

        public async Task<List<Exercise>> GetAllExercisesAsync()
        {
            return await _exerciseRepository.GetAllExercisesAsync();    
        }

        public async Task<Exercise> GetExerciseByIdAsync(int Exerciseid)
        {
            return await _exerciseRepository.GetExerciseByIdAsync(Exerciseid);
        }

        public async Task<Exercise> UpdateExerciseAsync(Exercise exercise)
        {
            return await _exerciseRepository.UpdateExerciseAsync(exercise);      
        }
       
    }
}
