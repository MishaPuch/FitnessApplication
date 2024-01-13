using FitnessApp.DAL.ViewModel;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Interface
{
    public interface ITrainingAndDietSchedule
    {
        public Task<List<FullModel>> GetUserTodaysPlanAsync(int userId);
        public Task<List<FullModel>> GetAllPlans();
        public Task<List<FullModel>> GetDalyPlanAsync(int userId, DateTime day);
        public  Task<List<FullModel>> GetAllUserPlansAsync(int userId);
        public Task<TreningAndDietSchedule> MakeADayInTreningAndSchedulesAsync(int userId , DateTime date);
        public Task<List<TreningAndDietSchedule>> MakeAMonthInTreningAndSchedulesAsync(int userId, DateTime date);
        public Task<FitnessApp.Models.TreningAndDietSchedule> GetTreningAndDietSchedulesByIdAsync(int id);

    }
}
