using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.DiRepositories
{
    public class CalorificCoefficientRepository : ICalorificCoefficientRepository
    {
        private readonly FitnessAppContext _context;
        public CalorificCoefficientRepository(FitnessAppContext context)
        {
            _context = context; 
        }

        public async Task<CalorificCoefficientValue> GetCoefficientValueByCaloryAndTypeOfMealAsync(int caloryValue, int typeOfMeal)
        {
            return await _context.CalorificCoefficientValues.FirstOrDefaultAsync(c=>(c.CalorificValue==caloryValue) && (c.TypeOfMeal.Id==typeOfMeal));
        }
    }
}
