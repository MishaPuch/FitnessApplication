using FitnessApp.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.interfaceRepositories
{
    public interface ITrainingAndDietScheduleRepository
    {
        public Task<List<TreningAndDietSchedule>> GetAllDaysPlansAsync();
        public Task<List<TreningAndDietSchedule>> GetDalyPlanAsync(int userId, DateTime day);
        public Task<List<TreningAndDietSchedule>> GetTodaysPlanAsync(int userId);
        public Task<TreningAndDietSchedule> GetTreningAndDietSchedulesByIdAsync(int id);
        public Task<List<TreningAndDietSchedule>> GetAllUserPlansAsync(int userId);
        public Task<TreningAndDietSchedule> MakeADayInTreningAndSchedulesAsync(int userId, DateTime date);
        public Task<List<TreningAndDietSchedule>> MakeAMonthInTreningAndSchedulesAsync(int userId, DateTime date);
        public Task<List<TreningAndDietSchedule>> GetTreningAndDietForRestMonthByUserIdAsync(int userId);
    }
}
