using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Interface
{
    public interface IMealService
    {
        public Task<Meal> GetMealByIdAsync(int Mealid);
        public Task<List<Meal>> GetAllMealsAsync();
        public Task CreateMealAsync(Meal meal);
        public Task<Meal> UpdateMealAsync(Meal meal);
        public Task DeleteMealAsync(int mealId);
    }
}
