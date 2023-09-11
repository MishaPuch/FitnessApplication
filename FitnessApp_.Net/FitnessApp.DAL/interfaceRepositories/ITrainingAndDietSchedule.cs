using FitnessApp.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.interfaceRepositories
{
    public interface ITrainingAndDietSchedule
    {
        public Task<List<TrainingAndDietSchedule>> GetAllDaysPlansAsync();
        public Task<List<TrainingAndDietSchedule>> GetDalyPlanAsync(int userId, DateTime day);
        public Task<List<TrainingAndDietSchedule>> GetTodaysPlanAsync(int userId);
        public Task<List<TrainingAndDietSchedule>> GetAllUserPlansAsync(int userId);
        
    }
}
