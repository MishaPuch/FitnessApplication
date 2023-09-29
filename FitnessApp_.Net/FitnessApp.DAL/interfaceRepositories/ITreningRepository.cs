using FitnessApp.DAL.Models;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.interfaceRepositories
{
    public interface ITreningRepository
    {
        public Task<Trening> GetTreningByIdAsync(int TreningId);
        public Task<List<Trening>> GetTreningsByTreningScheduleIdAsync(int TreningScheduleId);
        public Task<List<Trening>> MakeTreningForADayPushPullLegsAsync(TreningAndDietSchedule treningAndDietSchedule);
        public Task<List<Trening>> MakeTreningForADayUpperLowerAsync(TreningAndDietSchedule treningAndDietSchedule);
        public Task<List<Trening>> MakeTreningForAWeekAsync(List<TreningAndDietSchedule> treningAndDietSchedules);
        public Task<List<Trening>> MakeTreningForAMonthAsync(List<TreningAndDietSchedule> treningAndDietSchedules);

    }
}
