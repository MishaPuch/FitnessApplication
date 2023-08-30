using FitnessApp.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.interfaceRepositories
{
    public interface IDaysOfDietAndExerciseRepository
    {
        public Task<List<DaysOfDietAndExercise>> GetAllDaysPlansAsync();
        public Task<List<DaysOfDietAndExercise>> GetDalyPlanAsync(int userId, int month, int day);
        public Task<List<DaysOfDietAndExercise>> GetTodaysPlanAsync(int userId);
        
    }
}
