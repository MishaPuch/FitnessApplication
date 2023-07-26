using FitnessApp.DAL.InterfaceRepositories;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly FitnessAppContext _context;
        public ExerciseRepository(FitnessAppContext _context)
        {
            this._context = _context;
        }
        public async Task CreateExerciseAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            await SaveChangeAsync();
        }

        public async Task DeleteExerciseByIdAsync(int exerciseId)
        {
            _context.Exercises.Remove(await GetExerciseByIdAsync(exerciseId));
            await SaveChangeAsync();
        }

        public async Task<List<Exercise>> GetAllExercisesAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise> GetExerciseByIdAsync(int exerciseId)
        {
            return await _context.Exercises.FindAsync(exerciseId);
        }

        public async Task UpdateExerciseAsync(Exercise exercise)
        {
            var changingExercise = await _context.Exercises.FindAsync(exercise.id);
            changingExercise = exercise;
            await SaveChangeAsync();
        }
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
