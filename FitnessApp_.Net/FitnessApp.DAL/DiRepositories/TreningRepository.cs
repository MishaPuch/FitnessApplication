using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using FitnessApp.Models;
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
            return await _context.Trenings.Include(x=>x.Exercise).ThenInclude(x=>x.MuscleGroup).Include(x => x.Exercise).ThenInclude(x => x.TypeOfTrening).FirstOrDefaultAsync(t=>t.Id == treningId);
        }

        public async Task<List<Trening>> GetTreningsByTreningScheduleIdAsync(int TreningScheduleId)
        {
            return await _context.Trenings.Include(x => x.Exercise).ThenInclude(x => x.MuscleGroup).Include(x=>x.Exercise).ThenInclude(x=>x.TypeOfTrening).Where(x => x.TrainingAndDietSchedules.Id == TreningScheduleId).ToListAsync();
        }

        public async Task<List<Trening>> MakeTreningForADayAsync(int treningAndDietScheduleId , int muscleGroupId)
        {
            List<Trening> trenings = new List<Trening>();

            List<Exercise> exercises = await _context.Exercises.Where(x=>x.MuscleGroupId==muscleGroupId).ToListAsync();
            
            for (int i = 0; i < 7; i++)
            {
                Trening trening = GetRandomUniqueTreningInList(trenings, exercises,treningAndDietScheduleId);
                trenings.Add(trening);
            }
            return trenings;
            //добавить сюда больше упражнений и чтобы они не повторялись (7)
            //можнобудет добавить сюда проверку юзера и если у него стоит сколько-то упражнений,
                //то зациклить выбор упражнений или что-от ещё , и выставвить повторы

        }
        public Trening GetRandomUniqueTreningInList(List<Trening> trenings, List<Exercise> exercises, int treningAndDietScheduleId)
        {
            Random randomNumber = new Random();

            while (true)
            {
                Exercise exercise = exercises[randomNumber.Next(0, exercises.Count)];

                bool isExerciseUnique = true;
                foreach (Trening checkingTrening in trenings)
                {
                    if (exercise.Id == checkingTrening.ExerciseId)
                    {
                        isExerciseUnique = false;
                        break;
                    }
                }

                if (isExerciseUnique)
                {
                    Trening trening = new Trening();

                    trening.TrainingAndDietSchedulesId = treningAndDietScheduleId;
                    trening.ExerciseId = exercise.Id;
                    trening.Times = "3x12";
                    

                    return trening;
                }
            }
        }


        public Task<List<Trening>> MakeTreningForAWeekAsync(int treningAndDietScheduleId)
        {
            throw new NotImplementedException();/////////////////////////////////////gngente
        }
    }
}
