using FitnessApp.BLL.DI_Service;
using FitnessApp.BLL.Halpers;
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
    public class TrainingAndDietScheduleService : ITrainingAndDietScheduleService
    {
        private readonly DAL.interfaceRepositories.ITrainingAndDietScheduleRepository _trainingAndDietScheduleRepository;
        private readonly ITreningService _treningService;
        private readonly IDietService _dietService;
        private readonly IUserService _userService;
        private readonly ICalorificCoefficientRepository _calorificCoefficientService;
        private readonly IRoleService _roleService;
        private readonly ITreningPlanService _treningPlanService;

        public TrainingAndDietScheduleService(
            DAL.interfaceRepositories.ITrainingAndDietScheduleRepository trainingAndDietScheduleRepository,
            ITreningService treningService,
            IDietService dietService,
            IUserService userService,
            ICalorificCoefficientRepository calorificCoefficientService,
            IRoleService roleService, 
            ITreningPlanService treningPlanService
            )
        {
            _trainingAndDietScheduleRepository = trainingAndDietScheduleRepository;
            _treningService = treningService;  
            _dietService= dietService;
            _userService = userService;
            _calorificCoefficientService = calorificCoefficientService;
            _roleService = roleService;
            _treningPlanService= treningPlanService;
        }

        public async Task<List<FullModel>> GetAllPlans()
        {
            List<Models.TreningAndDietSchedule> allDaysPlans = await _trainingAndDietScheduleRepository.GetAllDaysPlansAsync();
            List<FullModel> fullModel = await MakefullModel( allDaysPlans );

            return fullModel;
        }

        public async Task<List<FullModel>> GetAllUserPlansAsync(int userId)
        {
            List<Models.TreningAndDietSchedule> allUserPlans = await _trainingAndDietScheduleRepository.GetAllUserPlansAsync(userId);
            List<FullModel> fullModel= await MakefullModel(allUserPlans);

            return fullModel;
        }

        public async Task<List<FullModel>> GetDalyPlanAsync(int userId, DateTime day)
        {
            List<Models.TreningAndDietSchedule> dalyPlan = await _trainingAndDietScheduleRepository.GetDalyPlanAsync(userId, day);
            List<FullModel> fullModel = await MakefullModel(dalyPlan);

            return fullModel;
        }

        public async Task<List<TreningAndDietSchedule>> GetTreningAndDietForRestMonthByUserId(int userId)
        {
            return await _trainingAndDietScheduleRepository.GetTreningAndDietForRestMonthByUserIdAsync(userId);
        }

        public async Task<TreningAndDietSchedule> GetTreningAndDietSchedulesByIdAsync(int id)
        {
            return await _trainingAndDietScheduleRepository.GetTreningAndDietSchedulesByIdAsync(id);
        }

        public async Task<List<FullModel>> GetUserTodaysPlanAsync(int userId)
        {
            List<Models.TreningAndDietSchedule> todaysPlan = await _trainingAndDietScheduleRepository.GetTodaysPlanAsync(userId);
            List<FullModel> fullModel = await MakefullModel(todaysPlan);

            return fullModel;
        }

        public async Task<Models.TreningAndDietSchedule> MakeADayInTreningAndSchedulesAsync(int userId, DateTime date)
        {
            return await _trainingAndDietScheduleRepository.MakeADayInTreningAndSchedulesAsync(userId, date);
        }

        public async Task<List<Models.TreningAndDietSchedule>> MakeAMonthInTreningAndSchedulesAsync(int userId, DateTime date)
        {   

            return await _trainingAndDietScheduleRepository.MakeAMonthInTreningAndSchedulesAsync(userId,date);
        }

        public async Task<List<FullModel>> MakefullModel(List<Models.TreningAndDietSchedule> daysOfDietAndExercises)
        {
            List<FullModel> daysJSON = new List<FullModel>();

            foreach (Models.TreningAndDietSchedule day in daysOfDietAndExercises)
            {

                FullModel fullModel = new FullModel();

                fullModel.Id = day.Id;
                fullModel.Day = day.Day;
                fullModel.Trening = await _treningService.GetTreningsByTreningScheduleIdAsync(day.Id);
                fullModel.User = await _userService.GetUserByIdAsync(day.UserId);
                fullModel.Diet = await _dietService.GetDietByTreningScheduleIdAsync(day.Id);
                fullModel.Role=await _roleService.GetByUserIdAsync(day.User.RoleId);
                fullModel.TreningPlan = await _treningPlanService.GetTreningPlanByIdAsync(day.User.TreningPlanId);
                foreach(var trening in fullModel.Trening)
                {
                    trening.Exercise.ExerciseVideo = "https://fitnessapp.blob.core.windows.net/exercisevideos/" + trening.Exercise.ExerciseVideo + ".jpg";
                }
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
