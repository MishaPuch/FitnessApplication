using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.DiRepositories
{
    public class MealRepository : IMealRepository
    {
        private readonly FitnessAppContext _context;
        public MealRepository(FitnessAppContext context)
        {
            _context = context;
        }
        public async Task<Meal> GetMealByIdAsync(int mealId)
        {
            return await _context.Meals.Include(x=>x.TypeOfMeal).FirstOrDefaultAsync(m=>m.Id==mealId);
        }
    }
}
