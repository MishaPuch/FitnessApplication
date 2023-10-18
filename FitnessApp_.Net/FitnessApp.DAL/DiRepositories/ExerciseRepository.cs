using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public async Task CreateExerciseAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExerciseAsync(int exerciseId)
        {
            var exercise = await _context.Exercises.FindAsync(exerciseId);
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Exercise>> GetAllExercisesAsync()
        {
            return await _context.Exercises.Include(x => x.MuscleGroup).Include(x => x.TypeOfTrening).ToListAsync();
        }

        public async Task<Exercise> GetExerciseByIdAsync(int exerciseid)
        {
            return await _context.Exercises.Include(x => x.MuscleGroup).Include(x => x.TypeOfTrening).FirstOrDefaultAsync(e => e.Id == exerciseid);
        }

        public async Task<Exercise> UpdateExerciseAsync(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
            await _context.SaveChangesAsync();
            return exercise;
            
        }
    }
}
