using FitnessApp.BLL.Interface;
using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Meal> GetMealByIdAsync(int MealId)
        {
            return await _mealRepository.GetMealByIdAsync(MealId);
        }
    }
}
