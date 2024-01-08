using FitnessApp.BLL.Halpers;
using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.DiRepositories
{
    public class TrainingAndDietScheduleRepository : ITrainingAndDietScheduleRepository
    {
        private readonly FitnessAppContext _context;
        public TrainingAndDietScheduleRepository(FitnessAppContext context) 
        { 
            _context = context;
        }
        public async Task<List<FitnessApp.Models.TreningAndDietSchedule>> GetAllDaysPlansAsync()    
        {
            return await _context.TrainingAndDietSchedule
                .Include(x=>x.Trainings)
                .Include(x=>x.User)
                .Include(x=>x.Diets)
                .ToListAsync();
        }

        public async Task<List<FitnessApp.Models.TreningAndDietSchedule>> GetDalyPlanAsync(int userId, DateTime day)
        {
            return await _context.TrainingAndDietSchedule
                .Include(x => x.Trainings)
                .Include(x => x.User)
                .Include(x => x.Diets)
                .Where(u=> (u.User.Id == userId)&&(u.Day==day))
                .ToListAsync();
        }

        public async Task<List<FitnessApp.Models.TreningAndDietSchedule>> GetTodaysPlanAsync(int userId)
        {
            return await _context.TrainingAndDietSchedule
                .Include(x => x.Trainings)
                .Include(x => x.User)
                .Include(x => x.Diets)
                .Where(u => (u.User.Id == userId) && (u.Day == DateTime.Now.Date))
                .ToListAsync(); 
        }
        public async Task<List<FitnessApp.Models.TreningAndDietSchedule>> GetAllUserPlansAsync(int userId)
        {
            return await _context.TrainingAndDietSchedule
                .Include(x => x.Trainings)
                .Include(x => x.User)
                .Include(x => x.Diets)
                .Where(u => u.User.Id == userId)
                .ToListAsync();
        }

        public async Task<FitnessApp.Models.TreningAndDietSchedule> MakeADayInTreningAndSchedulesAsync(int userId, DateTime date)
        {
            TreningAndDietSchedule trainingAndDietForSpecificDay = new TreningAndDietSchedule();
            trainingAndDietForSpecificDay.Day = date;
            trainingAndDietForSpecificDay.UserId = userId;
            
            await _context.TrainingAndDietSchedule.AddAsync(trainingAndDietForSpecificDay);
            return trainingAndDietForSpecificDay;
        }

        public async Task<List<FitnessApp.Models.TreningAndDietSchedule>> MakeAMonthInTreningAndSchedulesAsync(int userId, DateTime date)
        {
            int daysInMonth= DateTimeHelper.GetQuantityDaysInMonth(date);
            DateTime day = date;
            List<TreningAndDietSchedule> trainingAndDietScheduleForAllMonth = new List<TreningAndDietSchedule>();

            for(int i = 0;i<daysInMonth; i++)
            {
                TreningAndDietSchedule schedule =await MakeADayInTreningAndSchedulesAsync(userId, day);
                trainingAndDietScheduleForAllMonth.Add(schedule);
                day=day.AddDays(1);
            }
            
            await _context.AddRangeAsync(trainingAndDietScheduleForAllMonth);
            await _context.SaveChangesAsync();

            return trainingAndDietScheduleForAllMonth;
        }
    }
}
