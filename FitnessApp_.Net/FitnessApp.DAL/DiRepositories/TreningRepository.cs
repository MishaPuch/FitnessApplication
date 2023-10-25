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

        public async Task<List<Trening>> MakeTreningForADayPushPullLegsAsync(TreningAndDietSchedule treningAndDietSchedule)
        {
            List<Trening> trenings = new List<Trening>();

            List<TypeOfMuscleGroup> typeOfMuscleGroup = new List<TypeOfMuscleGroup>();
            //можно будет вынести как план \/ и добавить разные планы 
            // доработать чтобы составляло тренировки для зала и дома
            if (treningAndDietSchedule.Day.DayOfWeek == DayOfWeek.Tuesday)// можно сюда добавить проверку в какой день юзер хочет тренироваться 
            {
                typeOfMuscleGroup = await _context.TypeOfMuscleGroups.Where(x => (x.FullBodyWorkoutProtogonistMuscleGroups == 1)//можно будет сюда добавить проверку какие мышцы юзер хочет тренеровать
                || (x.FullBodyWorkoutProtogonistMuscleGroups == 0)).ToListAsync();
            }
            else if (treningAndDietSchedule.Day.DayOfWeek == DayOfWeek.Thursday)
            {
                typeOfMuscleGroup = await _context.TypeOfMuscleGroups.Where(x => x.FullBodyWorkoutProtogonistMuscleGroups == 2).ToListAsync();
            }
            else if (treningAndDietSchedule.Day.DayOfWeek == DayOfWeek.Saturday)
            {
                typeOfMuscleGroup = await _context.TypeOfMuscleGroups.Where(x => (x.FullBodyWorkoutProtogonistMuscleGroups == 3) 
                || (x.FullBodyWorkoutProtogonistMuscleGroups == 0)).ToListAsync();
            }

            foreach (var muscleGroup in typeOfMuscleGroup)
            {
                List<TypeOfTrening> typesOfTrening = await _context.TypesOfTrening.ToListAsync();
                foreach (var typeOfTrening in typesOfTrening)
                {
                    List<Exercise> exercises = await _context.Exercises.Where(x => (x.MuscleGroupId == muscleGroup.Id)&&(x.TypeOfTrening.Id==typeOfTrening.Id)).ToListAsync();

                    for (int i = 0; i < 3; i++)
                    {
                        Trening trening = GetRandomUniqueTreningInList(trenings, exercises, treningAndDietSchedule.Id);
                        trenings.Add(trening);
                    }
                }
            }
            return trenings;
            //можнобудет добавить сюда проверку юзера и если у него стоит сколько-то упражнений,
                //то зациклить выбор упражнений или что-от ещё , и выставвить повторы

        }
        public Trening GetRandomUniqueTreningInList(List<Trening> trenings, List<Exercise> exercises, int treningAndDietScheduleId)
        {
            Random randomNumber = new Random();
            int maxAttempts = 100; // Максимальное количество попыток для поиска уникального упражнения
            int attempts = 0; // Счетчик попыток

            while (attempts < maxAttempts)
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
                    trening.Times = "3x10";

                    return trening;
                }

                attempts++;

                // Если не удается найти уникальное упражнение после maxAttempts попыток, выходим из цикла
                if (attempts >= maxAttempts)
                {
                    // Вернуть значение по умолчанию, чтобы обозначить, что уникальное упражнение не было найдено
                    return null;
                }
            }

            // Вернуть null, если не удается найти уникальное упражнение
            return null;
        }



        public async Task<List<Trening>> MakeTreningForAWeekAsync(List<TreningAndDietSchedule> treningAndDietSchedules)
        {
            List<Trening> treningsForAWeek = new List<Trening>();

            for (int i = 0; i < 7; i++)
            {
                List<TreningAndDietSchedule> treningSchedulesCopy = new List<TreningAndDietSchedule>(treningAndDietSchedules);
                List<Trening> treningsForOneDay=new List<Trening>();

                if (treningAndDietSchedules[0].User.TreningPlanId == 1)
                {
                    treningsForOneDay = await MakeTreningForADayPushPullLegsAsync(treningSchedulesCopy[i]);
                }
                else if (treningAndDietSchedules[0].User.TreningPlanId == 2)
                {
                    treningsForOneDay = await MakeTreningForADayUpperLowerAsync(treningSchedulesCopy[i]);

                }
              
                treningsForAWeek.AddRange(treningsForOneDay);
            }

            return treningsForAWeek;
        }



        public async Task<List<Trening>> MakeTreningForAMonthAsync(List<TreningAndDietSchedule> treningAndDietSchedules)
        {
            List<Trening> FullMonthTrening = new List<Trening>();

            int quantityDaysInMonth = treningAndDietSchedules.Count;
            int weeksInMonth = quantityDaysInMonth / 7;
            int restDaysInMonth = quantityDaysInMonth % 7;

            for (int i = 0; i < weeksInMonth; i++)
            {
                List<Trening> treningsForAWeek = await MakeTreningForAWeekAsync(treningAndDietSchedules.Take(7).ToList());
                FullMonthTrening.AddRange(treningsForAWeek);
                treningAndDietSchedules = treningAndDietSchedules.Skip(7).ToList(); 
            }

            if (restDaysInMonth > 0)
            {
                List<Trening> treningForRestDays = new List<Trening>();

                foreach (TreningAndDietSchedule treningAndDietSchedule in treningAndDietSchedules)
                {
                    List<Trening> treningForOneDay = new List<Trening>();

                    if (treningAndDietSchedule.User.TreningPlanId == 1)
                    { 
                         treningForOneDay = await MakeTreningForADayPushPullLegsAsync(treningAndDietSchedule);
                    }
                    else if(treningAndDietSchedule.User.TreningPlanId == 2)
                    {
                        treningForOneDay = await MakeTreningForADayUpperLowerAsync(treningAndDietSchedule);

                    }
                    treningForRestDays.AddRange(treningForOneDay);
                }
                FullMonthTrening.AddRange(treningForRestDays);
            }

            await _context.AddRangeAsync(FullMonthTrening);
            await _context.SaveChangesAsync();

            return FullMonthTrening;
        }
        public async Task<List<Trening>> MakeTreningForADayUpperLowerAsync(TreningAndDietSchedule treningAndDietSchedule)
        {
            List<Trening> trenings = new List<Trening>();

            List<TypeOfMuscleGroup> typeOfMuscleGroup = new List<TypeOfMuscleGroup>();
            //можно будет вынести как план \/ и добавить разные планы 
            // доработать чтобы составляло тренировки для зала и дома

            if (treningAndDietSchedule.Day.DayOfWeek == DayOfWeek.Tuesday)// можно сюда добавить проверку в какой день юзер хочет тренироваться 
            {
                typeOfMuscleGroup = await _context.TypeOfMuscleGroups.Where(x => (x.FullBodyWorkoutProtogonistMuscleGroups == 1)//можно будет сюда добавить проверку какие мышцы юзер хочет тренеровать
                || (x.FullBodyWorkoutProtogonistMuscleGroups == 2)).ToListAsync();
            }
         
            else if (treningAndDietSchedule.Day.DayOfWeek == DayOfWeek.Thursday)
            {
                typeOfMuscleGroup = await _context.TypeOfMuscleGroups.Where(x => (x.FullBodyWorkoutProtogonistMuscleGroups == 3)
                || (x.FullBodyWorkoutProtogonistMuscleGroups == 0)).ToListAsync();
            }
            if (treningAndDietSchedule.Day.DayOfWeek == DayOfWeek.Saturday)// можно сюда добавить проверку в какой день юзер хочет тренироваться 
            {
                typeOfMuscleGroup = await _context.TypeOfMuscleGroups.Where(x => (x.FullBodyWorkoutProtogonistMuscleGroups == 1)//можно будет сюда добавить проверку какие мышцы юзер хочет тренеровать
                || (x.FullBodyWorkoutProtogonistMuscleGroups == 2)).ToListAsync();
            }
            else if (treningAndDietSchedule.Day.DayOfWeek == DayOfWeek.Sunday)
            {
                typeOfMuscleGroup = await _context.TypeOfMuscleGroups.Where(x => (x.FullBodyWorkoutProtogonistMuscleGroups == 3)
                || (x.FullBodyWorkoutProtogonistMuscleGroups == 0)).ToListAsync();
            }

            foreach (var muscleGroup in typeOfMuscleGroup)
            {
                List<TypeOfTrening> typesOfTrening = await _context.TypesOfTrening.ToListAsync();
                foreach (var typeOfTrening in typesOfTrening)
                {
                    List<Exercise> exercises = await _context.Exercises.Where(x => (x.MuscleGroupId == muscleGroup.Id) && (x.TypeOfTrening.Id == typeOfTrening.Id)).ToListAsync();

                    for (int i = 0; i < 4; i++)
                    {
                        Trening trening = GetRandomUniqueTreningInList(trenings, exercises, treningAndDietSchedule.Id);
                        trenings.Add(trening);
                    }
                }
            }
            return trenings;
            //можнобудет добавить сюда проверку юзера и если у него стоит сколько-то упражнений,
            //то зациклить выбор упражнений или что-от ещё , и выставвить повторы

        }
    }
}
