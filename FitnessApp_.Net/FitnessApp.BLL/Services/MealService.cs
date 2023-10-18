using FitnessApp.BLL.Interface;
using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        public MealService(IMealRepository mealRepository)
        {
            _mealRepository= mealRepository;
        }

        public async Task CreateMealAsync(Meal meal)
        {
            await _mealRepository.CreateMealAsync(meal);
        }

        public async Task DeleteMealAsync(int mealId)
        {
            await _mealRepository.DeleteMealAsync(mealId);
        }

        public async Task<List<Meal>> GetAllMealsAsync()
        {
           return await _mealRepository.GetAllMealsAsync();  
        }

        public async Task<Meal> GetMealByIdAsync(int MealId)
        {
            return await _mealRepository.GetMealByIdAsync(MealId);
        }

        public async Task<Meal> UpdateMealAsync(Meal meal)
        {
            return await _mealRepository.UpdateMealAsync(meal);
        }
    }
}
