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
    public class TypeOfMealRepository : ITypeOfMealRepository
    {
        private readonly FitnessAppContext _context;
        public TypeOfMealRepository(FitnessAppContext context)
        {
            _context = context;
        }
        public async Task<TypeOfMeal> GetTypeOfMealByIdAsync(int typeOfMealId)
        {
            return await _context.TypesOfMeal.FirstOrDefaultAsync(t=>t.Id == typeOfMealId);
        }
    }
}
