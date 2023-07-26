using FitnessApp.DAL.InterfaceRepositories;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.repositories
{
    public class DietRepository : IDietRepository
    {
        private readonly FitnessAppContext _context;
        public DietRepository(FitnessAppContext _context)
        {
            this._context = _context;
        }
        public async Task CreateDietAsync(Diet diet)
        {
            _context.Diet.Add(diet);
            await SaveChangeAsync();
        }

        public async Task DeleteDietByIdAsync(int dietId)
        {
            _context.Diet.Remove(await GetDietByIdAsync(dietId));
            await SaveChangeAsync();
        }

        public async Task<List<Diet>> GetAllDietAsync()
        {
            return await _context.Diet.ToListAsync();
        }

        public async Task<Diet> GetDietByCalorifieAsync(int dietCalorific)
        {
            return await _context.Diet.FirstOrDefaultAsync(d => d.calorificValue == dietCalorific);
        }

        public async Task<Diet> GetDietByIdAsync(int dietId)
        {
            return await _context.Diet.FirstOrDefaultAsync(d => d.id == dietId);
        }

        public async Task UpdateDietAsync(Diet diet)
        {
            var changingDiet= await _context.Diet.FindAsync(diet.id);
            changingDiet = diet;
            await SaveChangeAsync();
        }
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
