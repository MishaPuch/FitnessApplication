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

        public async Task CreateMealAsync(Meal meal)
        {
            await _context.Meals.AddAsync(meal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMealAsync(int mealId)
        {
            var meal= await _context.Meals.FindAsync(mealId);
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();  
        }

        public async Task<List<Meal>> GetAllMealsAsync()
        {
            return await _context.Meals.Include(x => x.TypeOfMeal).ToListAsync();
        }

        public async Task<Meal> GetMealByIdAsync(int mealId)
        {
            return await _context.Meals.Include(x=>x.TypeOfMeal).FirstOrDefaultAsync(m=>m.Id==mealId);
        }

        public async Task<Meal> UpdateMealAsync(Meal meal)
        {
            _context.Meals.Update(meal);
            await _context.SaveChangesAsync();
            return meal;
        }
    }
}
