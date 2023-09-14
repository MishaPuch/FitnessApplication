﻿using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.DiRepositories
{
    public class DietRepository : IDietRepository
    {
        private readonly FitnessAppContext _context;
        public DietRepository(FitnessAppContext context)
        {
            _context = context;
        }

        public async Task<Diet> GetDietByIdAsync(int dietId)
        {
            return await _context.Diet.Include(x=>x.Meal).ThenInclude(x=>x.TypeOfMeal).FirstOrDefaultAsync(d=>d.Id== dietId);
        }

        public async Task<List<Diet>> GetDietByTreningScheduleIdAsync(int treningScheduleId)
        {
            return await _context.Diet.Include(x => x.Meal).ThenInclude(x => x.TypeOfMeal).Where(x => x.TrainingAndDietSchedule.Id == treningScheduleId).ToListAsync();
        }

        public async Task<List<Diet>> MakeDietForADayAsync(int treningAndDietScheduleId)
        {
            List<Diet> dietsForOneDay = new List<Diet>();

            List<Meal> breakfasts = await _context.Meals.Where(x => x.TypeOfMealId == 1).ToListAsync();
            List<Meal> lunchs = await _context.Meals.Where(x => x.TypeOfMealId == 2).ToListAsync();
            List<Meal> dinners = await _context.Meals.Where(x => x.TypeOfMealId == 3).ToListAsync();
            List<Meal> snaks = await _context.Meals.Where(x => x.TypeOfMealId == 4).ToListAsync();

            Diet breakfast = GetRandomUniqueDietInList(dietsForOneDay, breakfasts, treningAndDietScheduleId);
            Diet lunch = GetRandomUniqueDietInList(dietsForOneDay, lunchs, treningAndDietScheduleId);
            Diet dinner = GetRandomUniqueDietInList(dietsForOneDay, dinners, treningAndDietScheduleId);
            Diet snak = GetRandomUniqueDietInList(dietsForOneDay, snaks, treningAndDietScheduleId);

            dietsForOneDay.Add(breakfast);
            dietsForOneDay.Add(lunch);
            dietsForOneDay.Add(dinner);
            dietsForOneDay.Add(snak);

            return dietsForOneDay;
            //можнобудет добавить сюда проверку юзера и если у него стоит 5 приёмов пищи , то зациклить снэки или что-от ещё
            //добавить сюда больше приёмов пищи (4-5)
        }
        public Diet GetRandomUniqueDietInList(List<Diet> diets ,List<Meal> meals ,int treningAndDietScheduleId)
        {
            Random randomNumber = new Random();

            while (true)
            {
                Meal meal = meals[randomNumber.Next(0, meals.Count)];

                bool isMealUnique = true;
                foreach (Diet checkingDiet in diets)
                {
                    if (meal.Id == checkingDiet.MealId)
                    {
                        isMealUnique = false;
                        break;
                    }
                }

                if (isMealUnique)
                {
                    Diet diet = new Diet();
                    diet.TrainingAndDietScheduleId = treningAndDietScheduleId;
                    diet.MealId = meal.Id;
                        
                    return diet;
                }
            }
        }

        public async Task<List<Diet>> MakeDietForAWeekAsync(List<TreningAndDietSchedule> treningAndDietSchedules)
        {
            List<Diet> dietsForOneWeek = new List<Diet>();

            List<Meal> breakfasts = await _context.Meals.Where(x => x.TypeOfMealId == 1).ToListAsync();
            List<Meal> lunchs = await _context.Meals.Where(x => x.TypeOfMealId == 2).ToListAsync();
            List<Meal> dinners = await _context.Meals.Where(x => x.TypeOfMealId == 3).ToListAsync();
            List<Meal> snaks = await _context.Meals.Where(x => x.TypeOfMealId == 4).ToListAsync();

            foreach (var treningSchedule in treningAndDietSchedules)
            {
                Diet breakfast = GetRandomUniqueDietInList(dietsForOneWeek, breakfasts, treningSchedule.Id);
                Diet lunch = GetRandomUniqueDietInList(dietsForOneWeek, lunchs, treningSchedule.Id);
                Diet dinner = GetRandomUniqueDietInList(dietsForOneWeek, dinners, treningSchedule.Id);
                Diet snak = GetRandomUniqueDietInList(dietsForOneWeek, snaks, treningSchedule.Id);

                dietsForOneWeek.Add(breakfast);
                dietsForOneWeek.Add(lunch);
                dietsForOneWeek.Add(dinner);
                dietsForOneWeek.Add(snak);
            }

            return dietsForOneWeek;
        }

        public async Task<List<Diet>> MakeDietForAMonthAsync(List<TreningAndDietSchedule> treningAndDietSchedules)
        {
            List<Diet> fullMonthDiet = new List<Diet>();

            int quantityDaysInMonth = treningAndDietSchedules.Count;
            int weeksInMonth = quantityDaysInMonth / 7;
            int restDaysInMonth = quantityDaysInMonth % 7;

            for (int i = 0; i < weeksInMonth; i++)
            {
                List<Diet> dietForAWeek = await MakeDietForAWeekAsync(treningAndDietSchedules.Take(7).ToList()); //Take(7) - первые 7 элементов списка
                fullMonthDiet.AddRange(dietForAWeek);
                treningAndDietSchedules= treningAndDietSchedules.Skip(7).ToList(); // RemoveRange(0, 7) - 0 - индекс с которого начать , 7 - сколько элементов  
            }

            if (restDaysInMonth > 0)
            {
                List<Diet> dietForRestDays = new List<Diet>();
                foreach (TreningAndDietSchedule treningAndDietSchedule in treningAndDietSchedules)
                {
                    List<Diet> dietForOnetDay = await MakeDietForADayAsync(treningAndDietSchedule.Id);
                    dietForRestDays.AddRange(dietForOnetDay);
                }
                fullMonthDiet.AddRange(dietForRestDays);
            }

            await _context.AddRangeAsync(fullMonthDiet);
            await _context.SaveChangesAsync();

            return fullMonthDiet;
        }
        
    }
}
