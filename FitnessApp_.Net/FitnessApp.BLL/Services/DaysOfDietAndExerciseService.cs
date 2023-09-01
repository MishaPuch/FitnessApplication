using FitnessApp.BLL.DI_Service;
using FitnessApp.BLL.Interface;
using FitnessApp.DAL.DiRepositories;
using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.InterfaceRepositories;
using FitnessApp.DAL.Models;
using FitnessApp.DAL.ViewModel;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Services
{
    public class DaysOfDietAndExerciseService : IDaysOfDietAndExerciseService
    {
        private readonly IDaysOfDietAndExerciseRepository _daysOfDietAndExerciseeRepository;
        private readonly ITreningService _treningService;
        private readonly IDietService _dietService;
        private readonly IUserService _userService;
        private readonly ICalorificCoefficientRepository _calorificCoefficientService;


        public DaysOfDietAndExerciseService(
            IDaysOfDietAndExerciseRepository daysOfDietAndExerciseRepository,
            ITreningService treningService,
            IDietService dietService,
            IUserService userService,
            ICalorificCoefficientRepository calorificCoefficientService
            )
        {
            _daysOfDietAndExerciseeRepository = daysOfDietAndExerciseRepository;
            _treningService = treningService;  
            _dietService= dietService;
            _userService = userService;
            _calorificCoefficientService = calorificCoefficientService;
        }

        public async Task<List<FullModel>> GetAllPlans()
        {
            List<DaysOfDietAndExercise> allDaysPlans = await _daysOfDietAndExerciseeRepository.GetAllDaysPlansAsync();
            List<FullModel> fullModel = await MakefullModel( allDaysPlans );

            return fullModel;
        }

        public async Task<List<FullModel>> GetAllUserPlansAsync(int userId)
        {
            List<DaysOfDietAndExercise> allUserPlans = await _daysOfDietAndExerciseeRepository.GetAllUserPlansAsync(userId);
            List<FullModel> fullModel= await MakefullModel(allUserPlans);

            return fullModel;
        }

        public async Task<List<FullModel>> GetDalyPlanAsync(int userId, int month, int day)
        {
            List<DaysOfDietAndExercise> dalyPlan = await _daysOfDietAndExerciseeRepository.GetDalyPlanAsync(userId, month, day);
            List<FullModel> fullModel = await MakefullModel(dalyPlan);

            return fullModel;
        }

        public async Task<List<FullModel>> GetUserTodaysPlanAsync(int userId)
        {
            List<DaysOfDietAndExercise> todaysPlan = await _daysOfDietAndExerciseeRepository.GetTodaysPlanAsync(userId);
            List<FullModel> fullModel = await MakefullModel(todaysPlan);

            return fullModel;
        }

        public async Task<List<FullModel>> MakefullModel(List<DaysOfDietAndExercise> daysOfDietAndExercises)
        {
            List<FullModel> daysJSON = new List<FullModel>();

            foreach (DaysOfDietAndExercise day in daysOfDietAndExercises)
            {
                FullModel fullModel = new FullModel();



                fullModel.Id = day.Id;
                fullModel.DayId = day.DayId;
                fullModel.Times = day.Times;
                fullModel.Trening = await _treningService.GetTreningByIdAsync(day.TreningId);
                fullModel.User = await _userService.GetUserByIdAsync(day.UserId);
                fullModel.Diet = await _dietService.GetDietByIdAsync(day.DietId);
                fullModel.Month = day.Month;

                CalorificCoefficientValue coefficientValue = await _calorificCoefficientService.GetCoefficientValueByCaloryAndTypeOfMealAsync(fullModel.User.CalorificValue, fullModel.Diet.Meal.TypeOfMealId);

                fullModel.Diet.Meal.Fat = fullModel.Diet.Meal.Fat * coefficientValue.CalorificCoefficient;
                fullModel.Diet.Meal.Carbon = fullModel.Diet.Meal.Carbon * coefficientValue.CalorificCoefficient;
                fullModel.Diet.Meal.Protein = fullModel.Diet.Meal.Protein * coefficientValue.CalorificCoefficient;
                fullModel.Diet.Meal.CalorificOfMeal = fullModel.Diet.Meal.CalorificOfMeal * coefficientValue.CalorificCoefficient;
               
                daysJSON.Add(fullModel);
            }
            return daysJSON;
        }
        
        
    }
}
