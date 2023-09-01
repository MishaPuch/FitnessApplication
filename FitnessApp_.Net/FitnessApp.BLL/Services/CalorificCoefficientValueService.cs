using FitnessApp.BLL.Interface;
using FitnessApp.DAL.DiRepositories;
using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Services
{
    public class CalorificCoefficientValueService : ICalorificCoefficientValueService
    {
        private CalorificCoefficientRepository _calorificCoefficientRepository;
        public CalorificCoefficientValueService(CalorificCoefficientRepository calorificCoefficientRepository) 
        {
            _calorificCoefficientRepository = calorificCoefficientRepository;
        }
        public async Task<CalorificCoefficientValue> GetCoefficientValueByCaloryAndTypeOfMealAsync(int caloryValue, int typeOfMeal)
        {
            return await _calorificCoefficientRepository.GetCoefficientValueByCaloryAndTypeOfMealAsync(caloryValue, typeOfMeal);
        }
    }
}
