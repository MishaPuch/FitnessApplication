using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using FitnessApp.Models;
using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Interface
{
    public class TreningService : ITreningService
    {
        private readonly ITreningRepository _treningRepository;
        public TreningService(ITreningRepository treningRepository)
        {
            _treningRepository = treningRepository;
        }

        public async Task<Trening> GetTreningByIdAsync(int treningId)
        {
            return await _treningRepository.GetTreningByIdAsync(treningId);
        }
        public async Task<List<Trening>> GetTreningsByTreningScheduleIdAsync(int treningAndDietSheduleId)
        {
            return await _treningRepository.GetTreningsByTreningScheduleIdAsync(treningAndDietSheduleId);
        }

        public async Task<List<Trening>> MakeTreningForADayPushPullLegsAsync(TreningAndDietSchedule treningAndDietSchedule)
        {

            return await _treningRepository.MakeTreningForADayPushPullLegsAsync(treningAndDietSchedule);                      
        }
        public async Task<List<Trening>> MakeTreningForADayUpperLowerAsync(TreningAndDietSchedule treningAndDietSchedule)
        {

            return await _treningRepository.MakeTreningForADayUpperLowerAsync(treningAndDietSchedule);
        }

        public async Task<List<Trening>> MakeTreningForAMonthAsync(List<TreningAndDietSchedule> treningAndDietSchedules , int treningPlanId)
        {
            return await _treningRepository.MakeTreningForAMonthAsync (treningAndDietSchedules, treningPlanId);
        }

        public async Task<List<Trening>> MakeTreningForAWeekAsync(List<TreningAndDietSchedule> treningAndDietSchedules , int treningPlanId)
        {
            return await _treningRepository.MakeTreningForAWeekAsync (treningAndDietSchedules, treningPlanId);
        }

    }
}
