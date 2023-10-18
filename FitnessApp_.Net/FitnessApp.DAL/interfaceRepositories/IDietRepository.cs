using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.interfaceRepositories
{
    public interface IDietRepository
    {
        public  Task<List<Diet>> GetAllDietsAsync();
        public Task DeleteDietAsync(int dietId);
        public Task<Diet> GetDietByIdAsync(int dietId);
        public Task<List<Diet>> GetDietByTreningScheduleIdAsync(int treningScheduleId);
        public Task<List<Diet>> MakeDietForADayAsync(int treningAndDietScheduleId);
        public Task<List<Diet>> MakeDietForAWeekAsync(List<TreningAndDietSchedule> treningAndDietSchedules);
        public Task<List<Diet>> MakeDietForAMonthAsync(List<TreningAndDietSchedule> treningAndDietSchedules);
    }
}
