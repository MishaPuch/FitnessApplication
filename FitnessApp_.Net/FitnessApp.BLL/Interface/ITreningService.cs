using FitnessApp.DAL.Models;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Interface
{
    public interface ITreningService
    {
        public Task<Trening> GetTreningByIdAsync(int treningId);
        public Task<List<Trening>> GetTreningsByTreningScheduleIdAsync(int treningAndDietSheduleId);
        public Task<List<Trening>> MakeTreningForADayPushPullLegsAsync(TreningAndDietSchedule treningAndDietSchedule);
        public Task<List<Trening>> MakeTreningForADayUpperLowerAsync(TreningAndDietSchedule treningAndDietSchedule);
        public Task<List<Trening>> MakeTreningForAWeekAsync(List<TreningAndDietSchedule> treningAndDietSchedules , int treningPlanId);
        public Task<List<Trening>> MakeTreningForAMonthAsync(List<TreningAndDietSchedule> treningAndDietSchedules, int treningPlanId);

    }
}
