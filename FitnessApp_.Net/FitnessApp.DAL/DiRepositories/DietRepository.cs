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
    public class DietRepository : IDietRepository
    {
        private readonly FitnessAppContext _context;
        public DietRepository(FitnessAppContext context)
        {
            _context = context;
        }

        public async Task<Diet> GetDietByIdAsync(int dietId)
        {
            return await _context.Diet.Include(x=>x.Meal).ThenInclude(x=>x.TypeOfMeal).FirstOrDefaultAsync(d=>d.Id== dietId);
        }

        public async Task<List<Diet>> GetDietByTreningScheduleIdAsync(int treningScheduleId)
        {
            return await _context.Diet.Include(x => x.Meal).ThenInclude(x => x.TypeOfMeal).Where(x => x.TrainingAndDietSchedule.Id == treningScheduleId).ToListAsync();
        }
    }
}
