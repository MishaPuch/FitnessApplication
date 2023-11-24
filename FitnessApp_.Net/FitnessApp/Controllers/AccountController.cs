using FitnessApp.BLL.DI_Service;
using FitnessApp.BLL.GetModels;
using FitnessApp.BLL.Interface;
using FitnessApp.BLL.Services;
using FitnessApp.BLL.Services.FileServices;
using FitnessApp.DAL.Helpers;
using FitnessApp.DAL.ViewModel;
using FitnessApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Globalization;
using System.IO;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserFileService _userFileService;
        private readonly MealFileService _mealFileService;
        private readonly IVereficationUserService _vereficationUserService;
        private readonly IUserService _userService;
        private readonly ITrainingAndDietSchedule _trainingAndDietSchedule;
        private readonly IDietService _dietService;
        private readonly ITreningService _treningService;
        private readonly IRoleService _roleService;
        private readonly QueueHelper _queueHelper;  
        private readonly ITreningPlanService _treningPlanService;
        
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public AccountController(
            IUserService userService,
            ITrainingAndDietSchedule trainingAndDietSchedule,
            IDietService dietService,
            ITreningService treningService,
            IRoleService roleService,
            ITreningPlanService treningPlanService,
            IVereficationUserService vereficationUserService,
            QueueHelper queueHelper
            )
        {
            _userService = userService;
            _trainingAndDietSchedule = trainingAndDietSchedule;
            _dietService = dietService;
            _treningService = treningService;
            _roleService = roleService;
            _treningPlanService = treningPlanService;
            _vereficationUserService = vereficationUserService;
            _queueHelper = queueHelper;
        }

        // GET: api/<AccountController>
        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await _userService.GetAllUsersAsync();
        }

        // GET: api/<AccountController>/GetUsers/user/{userId}
        [HttpGet("user/{userId:int}")]
        public async Task<User> GetUser(int userId)
        {
            return await _userService.GetUserByIdAsync(userId);
        }

        [HttpGet("user/{userEmail}/{password}")]
        public async Task<List<FullModel>> GetUserVerification(string userEmail, string password)
        {
            User? user = await _userService.GetUserByEmailAndPasswordAsync(userEmail, password);

            if (user != null)
            {
                await _queueHelper.EmailVereficationAsync(user);

                if (user.Role != null)  
                {
                    if (user.Role.ID == 2 || user.Role.ID == 3)
                    {
                        List<FullModel> result = new List<FullModel>
                        {
                            new FullModel
                            {
                                Day = DateTime.Now,
                                User = user,
                                Trening = null,
                                Diet = null,
                                TreningPlan = null,
                                Role = user.Role
                            }
                        };
                        return result;
                    }
                    else
                    {
                        var todaysPlan = await _trainingAndDietSchedule.GetUserTodaysPlanAsync(user.Id);
                        Logger.Info($"User was found: {user}");
                        return todaysPlan;
                    }
                }
                else
                {
                    // Возвращаем значение по умолчанию, если у пользователя нет роли
                    return new List<FullModel>();
                }
            }
            else
            {
                Logger.Info($"User was not found");
                return new List<FullModel>();
            }
        }


        [HttpPost("create-user")]
        public async Task<List<FullModel>> Register([FromBody] GetUser getCreatingUser)
        {
            try
            {
                User creatingUser = new User()
                {
                    UserName = getCreatingUser.UserName,
                    UserEmail = getCreatingUser.UserEmail,
                    Password = getCreatingUser.Password,
                    Sex = getCreatingUser.Sex,
                    Age = getCreatingUser.Age,
                    RestTime = getCreatingUser.RestTime,
                    CalorificValue = getCreatingUser.CalorificValue,
                    DateOFLastPayment = getCreatingUser.DateOFLastPayment,
                    TreningPlanId = getCreatingUser.TreningPlanId,
                    TreningPlan = await _treningPlanService.GetTreningPlanByIdAsync(getCreatingUser.TreningPlanId),
                    RoleId = getCreatingUser.RoleId,
                    Role = await _roleService.GetByUserIdAsync(getCreatingUser.RoleId),
                    IsEmailConfirmed = false, 
                };

                User checkingUser = await _userService.GetUserByEmailAsync(creatingUser.UserEmail);

                if (checkingUser != null)
                {
                    return await _trainingAndDietSchedule.GetUserTodaysPlanAsync(checkingUser.Id);
                }
                else
                {
                    
                    User user = await _userService.CreateUserAsync(creatingUser);

                    var treningAndDietSchedule = await _trainingAndDietSchedule.MakeAMonthInTreningAndSchedulesAsync(user.Id, user.DateOFLastPayment);
                    var dietForAMonth = await _dietService.MakeDietForAMonthAsync(treningAndDietSchedule);
                    var treningForAMonth = await _treningService.MakeTreningForAMonthAsync(treningAndDietSchedule);

                    return await _trainingAndDietSchedule.GetUserTodaysPlanAsync(user.Id);

                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Logger.Warn($"Internal Server Error: {ex.Message}");

                // Return an appropriate value or throw the exception again based on your requirements
                throw; // or return an appropriate value like an empty list
            }
        }



        // PUT: api/<AccountController>/changeData
        [HttpPut("changeData")]
        public async Task ChangeUserData([FromBody] GetUser getCreatingUser)
        {
            User user    = new User()
            {
                UserName = getCreatingUser.UserName,
                UserEmail = getCreatingUser.UserEmail,
                Password = getCreatingUser.Password,
                Sex = getCreatingUser.Sex,
                Age = getCreatingUser.Age,
                RestTime = getCreatingUser.RestTime,
                CalorificValue = getCreatingUser.CalorificValue,
                DateOFLastPayment = getCreatingUser.DateOFLastPayment,
                TreningPlanId = getCreatingUser.TreningPlanId,
                TreningPlan = await _treningPlanService.GetTreningPlanByIdAsync(getCreatingUser.TreningPlanId),
                RoleId = getCreatingUser.RoleId,
                Role = await _roleService.GetByUserIdAsync(getCreatingUser.RoleId),

            };
            await _userService.CangeUserDataAsync(user);
                Logger.Info($"user : {user.Id} - was saccesfully changed");
            
        }

        // DELETE: api/<AccountController>/DeleteUser/{userId}
        [HttpDelete("DeleteUser/{userId:int}")]
        public async Task DeleteUser(int userId)
        {
            await _userService.DeleteUserAsync(userId);
            Logger.Info($"user :id {userId} - was saccesfully deleted");
        }

        // PUT: api/<AccountController>/confirmationEmail/{email}/{vereficationCode}
        [HttpPut("confirmationEmail/{email}/{vereficationCode:int}")]
        public async Task ConfirmationEmail( string email , int vereficationCode)
        {
            await _vereficationUserService.CheckThePassword(email, vereficationCode);
        }
    }
}
