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
    public class TypeOfMealService : ITypeOfMealService
    {
        private readonly ITypeOfMealRepository _typeOfMealRepository;
        public TypeOfMealService(ITypeOfMealRepository typeOfMealRepository) 
        {
            _typeOfMealRepository = typeOfMealRepository;
        }
        public async Task<TypeOfMeal> GetTypeOfMealByIdAsync(int typeOfMealId)
        {
            return await _typeOfMealRepository.GetTypeOfMealByIdAsync(typeOfMealId);
        }
    }
}
