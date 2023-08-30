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

        public async Task<Exercise> GetExerciseByIdAsync(int Exerciseid)
        {
            return await _exerciseRepository.GetExerciseByIdAsync(Exerciseid);
        }
    }
}
