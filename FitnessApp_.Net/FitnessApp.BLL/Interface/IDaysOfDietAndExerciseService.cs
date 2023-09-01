using FitnessApp.DAL.ViewModel;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Interface
{
    public interface IDaysOfDietAndExerciseService
    {
        public Task<List<FullModel>> GetUserTodaysPlanAsync(int userId);
        public Task<List<FullModel>> GetAllPlans();
        public Task<List<FullModel>> GetDalyPlanAsync(int userId, int month, int day);
        public  Task<List<FullModel>> GetAllUserPlansAsync(int userId);
    }
}
