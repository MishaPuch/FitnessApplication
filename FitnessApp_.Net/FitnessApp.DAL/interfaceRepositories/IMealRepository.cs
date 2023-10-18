using FitnessApp.DAL.Models;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.interfaceRepositories
{
    public interface IMealRepository
    {
        public Task<Meal> GetMealByIdAsync(int mealId);
        public Task<List<Meal>> GetAllMealsAsync();
        public Task CreateMealAsync(Meal meal);
        public Task<Meal> UpdateMealAsync(Meal meal);
        public Task DeleteMealAsync(int mealId);


    }
}
