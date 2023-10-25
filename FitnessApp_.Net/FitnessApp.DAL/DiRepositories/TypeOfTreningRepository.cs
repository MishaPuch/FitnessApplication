using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.DiRepositories
{
    public class TypeOfTreningRepository : ITypeOfTreningRepository
    {
        private readonly FitnessAppContext _context;
        public TypeOfTreningRepository(FitnessAppContext context)
        {
            _context = context;
        }
        public async Task<TypeOfTrening> GetTypeOfTreningByIdAsync(int id)
        {
            return await _context.TypesOfTrening.FindAsync(id);
        }
    }
}
