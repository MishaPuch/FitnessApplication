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
    public class TrainingAndDietSchedule : ITrainingAndDietSchedule
    {
        private readonly FitnessAppContext _context;
        public TrainingAndDietSchedule(FitnessAppContext context) 
        { 
            _context = context;
        }
        public async Task<List<FitnessApp.Models.TrainingAndDietSchedule>> GetAllDaysPlansAsync()    
        {
            return await _context.TrainingAndDietSchedule.Include(x=>x.Trainings).Include(x=>x.User).Include(x=>x.Diets).ToListAsync();
        }

        public async Task<List<FitnessApp.Models.TrainingAndDietSchedule>> GetDalyPlanAsync(int userId, DateTime day)
        {
            return await _context.TrainingAndDietSchedule.Include(x => x.Trainings).Include(x => x.User).Include(x => x.Diets).Where(u=> (u.User.Id == userId)&&(u.Day==day)).ToListAsync();
        }

        public async Task<List<FitnessApp.Models.TrainingAndDietSchedule>> GetTodaysPlanAsync(int userId)
        {
            return await _context.TrainingAndDietSchedule.Include(x => x.Trainings).Include(x => x.User).Include(x => x.Diets).Where(u => (u.User.Id == userId) && (u.Day == DateTime.Now.Date)).ToListAsync(); 
        }
        public async Task<List<FitnessApp.Models.TrainingAndDietSchedule>> GetAllUserPlansAsync(int userId)
        {
            return await _context.TrainingAndDietSchedule.Include(x => x.Trainings).Include(x => x.User).Include(x => x.Diets).Where(u => u.User.Id == userId).ToListAsync();
        }
    }
}
