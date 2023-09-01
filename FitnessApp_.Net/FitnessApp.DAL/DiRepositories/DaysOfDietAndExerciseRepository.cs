using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.DiRepositories
{
    public class DaysOfDietAndExerciseRepository : IDaysOfDietAndExerciseRepository
    {
        private readonly FitnessAppContext _context;
        public DaysOfDietAndExerciseRepository(FitnessAppContext context) 
        { 
            _context = context;
        }
        public async Task<List<FitnessApp.Models.DaysOfDietAndExercise>> GetAllDaysPlansAsync()    
        {
            return await _context.DaysOfDietAndExercise.Include(x=>x.Trening).Include(x=>x.User).Include(x=>x.Diet).ToListAsync();
        }

        public async Task<List<FitnessApp.Models.DaysOfDietAndExercise>> GetDalyPlanAsync(int userId, int month, int dayId)
        {
            return await _context.DaysOfDietAndExercise.Include(x => x.Trening).Include(x => x.User).Include(x => x.Diet).Where(u=> (u.User.Id == userId)&&(u.Month==month)&&(u.DayId==dayId)).ToListAsync();
        }

        public async Task<List<FitnessApp.Models.DaysOfDietAndExercise>> GetTodaysPlanAsync(int userId)
        {
            return await _context.DaysOfDietAndExercise.Include(x => x.Trening).Include(x => x.User).Include(x => x.Diet).Where(u => (u.User.Id == userId) && (u.DayId == 1)).ToListAsync(); 
        }
        public async Task<List<FitnessApp.Models.DaysOfDietAndExercise>> GetAllUserPlansAsync(int userId)
        {
            return await _context.DaysOfDietAndExercise.Include(x => x.Trening).Include(x => x.User).Include(x => x.Diet).Where(u => u.User.Id == userId).ToListAsync();
        }
    }
}
