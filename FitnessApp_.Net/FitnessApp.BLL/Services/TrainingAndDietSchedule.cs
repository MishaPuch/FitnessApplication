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
    public class TrainingAndDietSchedule : Interface.ITrainingAndDietSchedule
    {
        private readonly DAL.interfaceRepositories.ITrainingAndDietSchedule _daysOfDietAndExerciseeRepository;
        private readonly ITreningService _treningService;
        private readonly IDietService _dietService;
        private readonly IUserService _userService;
        private readonly ICalorificCoefficientRepository _calorificCoefficientService;

        public TrainingAndDietSchedule(
            DAL.interfaceRepositories.ITrainingAndDietSchedule daysOfDietAndExerciseRepository,
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
            List<Models.TrainingAndDietSchedule> allDaysPlans = await _daysOfDietAndExerciseeRepository.GetAllDaysPlansAsync();
            List<FullModel> fullModel = await MakefullModel( allDaysPlans );

            return fullModel;
        }

        public async Task<List<FullModel>> GetAllUserPlansAsync(int userId)
        {
            List<Models.TrainingAndDietSchedule> allUserPlans = await _daysOfDietAndExerciseeRepository.GetAllUserPlansAsync(userId);
            List<FullModel> fullModel= await MakefullModel(allUserPlans);

            return fullModel;
        }

        public async Task<List<FullModel>> GetDalyPlanAsync(int userId, DateTime day)
        {
            List<Models.TrainingAndDietSchedule> dalyPlan = await _daysOfDietAndExerciseeRepository.GetDalyPlanAsync(userId, day);
            List<FullModel> fullModel = await MakefullModel(dalyPlan);

            return fullModel;
        }

        public async Task<List<FullModel>> GetUserTodaysPlanAsync(int userId)
        {
            List<Models.TrainingAndDietSchedule> todaysPlan = await _daysOfDietAndExerciseeRepository.GetTodaysPlanAsync(userId);
            List<FullModel> fullModel = await MakefullModel(todaysPlan);

            return fullModel;
        }

        public async Task<List<FullModel>> MakefullModel(List<Models.TrainingAndDietSchedule> daysOfDietAndExercises)
        {
            List<FullModel> daysJSON = new List<FullModel>();

            foreach (Models.TrainingAndDietSchedule day in daysOfDietAndExercises)
            {
                FullModel fullModel = new FullModel();

                fullModel.Id = day.Id;
                fullModel.Day = day.Day;
                fullModel.Trening = await _treningService.GetTreningsByTreningScheduleIdAsync(day.Id);
                fullModel.User = await _userService.GetUserByIdAsync(day.UserId);
                fullModel.Diet = await _dietService.GetDietByTreningScheduleIdAsync(day.Id);

                foreach (var diet in fullModel.Diet)
                {
                    CalorificCoefficientValue coefficientValue = await _calorificCoefficientService.GetCoefficientValueByCaloryAndTypeOfMealAsync(fullModel.User.CalorificValue, diet.Meal.TypeOfMeal.Id);

                    diet.Meal.Fat = diet.Meal.Fat * coefficientValue.CalorificCoefficient;
                    diet.Meal.Carbon = diet.Meal.Carbon * coefficientValue.CalorificCoefficient;
                    diet.Meal.Protein = diet.Meal.Protein * coefficientValue.CalorificCoefficient;
                    diet.Meal.CalorificOfMeal = diet.Meal.CalorificOfMeal * coefficientValue.CalorificCoefficient;
                }
                daysJSON.Add(fullModel);

            }
            return daysJSON;
        }
        
        
    }
}
