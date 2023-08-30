using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.interfaceRepositories
{
    public interface IExerciseRepository
    {
        public Task<Exercise> GetExerciseByIdAsync(int ExerciseId);
    }
}
