using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.DiRepositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly FitnessAppContext _context;
        public ExerciseRepository(FitnessAppContext context)
        {
            _context = context;
        }

        public async Task<Exercise> GetExerciseByIdAsync(int exerciseid)
        {
            var exercise = await _context.Exercises.Include(x=>x.MuscleGroup).FirstOrDefaultAsync(e => e.Id == exerciseid);
            return exercise;
        }
    }
}
