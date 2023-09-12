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
        public Task<List<Trening>> MakeTreningForADayAsync(int treningAndDietScheduleId , int muscleGroupId);
        public Task<List<Trening>> MakeTreningForAWeekAsync(int treningAndDietScheduleId);
    }
}
