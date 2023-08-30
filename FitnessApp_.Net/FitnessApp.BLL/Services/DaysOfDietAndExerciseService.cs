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
        private readonly ITypeOfMuscleGroupService _typeOfMuscleGroupService;
        private readonly ITreningService _treningService;
        private readonly IExerciseService _exerciseService;
        private readonly IDietService _dietService;
        private readonly IMealService _mealService;
        private readonly ITypeOfMealService _typeOfMealService;
        private readonly IUserService _userService;


        public DaysOfDietAndExerciseService(
            IDaysOfDietAndExerciseRepository daysOfDietAndExerciseRepository,
            ITypeOfMuscleGroupService typeOfMuscleGroupService,
            IExerciseService exerciseService,
            ITreningService treningService,
            IDietService dietService,
            IMealService mealService,
            ITypeOfMealService typeOfMealService,
            IUserService userService
            )
        {
            _daysOfDietAndExerciseeRepository = daysOfDietAndExerciseRepository;
            _typeOfMuscleGroupService = typeOfMuscleGroupService;
            _treningService = treningService;  
            _exerciseService= exerciseService;
            _dietService= dietService;
            _mealService= mealService;
            _typeOfMealService= typeOfMealService;
            _userService = userService;
        }

        public async Task<List<FullModel>> GetAllPlans()
        {
            List<DaysOfDietAndExercise> allDaysPlans = await _daysOfDietAndExerciseeRepository.GetAllDaysPlansAsync();
            List<FullModel> fullModel = await MakefullModel( allDaysPlans );

            return fullModel;
        }

        public async Task<List<FullModel>> GetDalyPlanAsync(int userId, int month, int day)
        {
            List<DaysOfDietAndExercise> dalyPlan = await _daysOfDietAndExerciseeRepository.GetDalyPlanAsync(userId, month, day);
            List<FullModel> fullModel = await MakefullModel(dalyPlan);

            return fullModel;
        }

        public async Task<List<FullModel>> GetTodaysPlanAsync(int userId)
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

                daysJSON.Add(fullModel);
            }
            return daysJSON;
        }
        
        
    }
}
