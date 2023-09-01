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
    public class TreningRepository : ITreningRepository
    {
        private readonly FitnessAppContext _context;
        public TreningRepository(FitnessAppContext context)
        {
            _context = context;
        }
        public async Task<Trening> GetTreningByIdAsync(int treningId)
        {
            return await _context.Trenings.Include(x=>x.Exercise).ThenInclude(x=>x.MuscleGroup).FirstOrDefaultAsync(t=>t.Id == treningId);
        }
    }
}
