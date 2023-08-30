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
        public Task<Exercise> GetExerciseByIdAsync(int Exerciseid);

    }
}
