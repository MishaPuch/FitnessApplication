using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.DiRepositories
{
    public class TreningPlanRepository:ITreningPlanRepository
    {
        private readonly FitnessAppContext _context;
        public TreningPlanRepository(FitnessAppContext context) 
        { 
            _context = context;
        }
        public async Task<TreningPlan> GetTreningPlanByIdAsync(int id)
        {
            return await _context.TreningPlans.FindAsync(id);
        }  
    }
}
