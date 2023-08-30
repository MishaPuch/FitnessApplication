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
    public class TypeOfMuscleGroupRepository : ITypeOfMuscleGroupRepository
    {
        private readonly FitnessAppContext _context;
        public TypeOfMuscleGroupRepository(FitnessAppContext context)
        {
            _context = context;
        }

        public async Task<TypeOfMuscleGroup> GetTypeOfMuscleGroupByIdAsync(int typeOfMuscleGroupRepositoryId)
        {
            return await _context.TypeOfMuscleGroups.FindAsync(typeOfMuscleGroupRepositoryId);
        }
    }
}
