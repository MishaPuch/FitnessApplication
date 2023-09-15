using FitnessApp.BLL.DI_Service;
using FitnessApp.BLL.Interface;
using FitnessApp.DAL.ViewModel;
using FitnessApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITrainingAndDietSchedule _trainingAndDietSchedule;
        private readonly IDietService _dietService;
        private readonly ITreningService _treningService;

        public AccountController(
            IUserService userService,
            ITrainingAndDietSchedule trainingAndDietSchedule,
            IDietService dietService,
            ITreningService treningService

            ) 
        { 
            _userService = userService;
            _trainingAndDietSchedule = trainingAndDietSchedule;
            _dietService=dietService;
            _treningService = treningService;
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

        // GET: api/<AccountController>/user/{userEmail}/{password}
        [HttpGet("user/{userEmail}/{password}")]
        public async Task<List<FullModel>> GetUserVerification(string userEmail, string password)
        {
            User? user = await _userService.GetUserByEmailAndPasswordAsync(userEmail, password);
            if (user != null)
                
                return await _trainingAndDietSchedule.GetUserTodaysPlanAsync(user.Id);
            else return new List<FullModel>();   
        }

        // POST: api/<AccountController>/create-user
        [HttpPost("create-user")]
        public async Task<List<FullModel>> Register([FromBody] User creatingUser)
        {
            User chekingUser = await _userService.GetUserByEmailAsync(creatingUser.UserEmail);

            if (chekingUser != null)
            {
                return await _trainingAndDietSchedule.GetUserTodaysPlanAsync(chekingUser.Id);
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

        // PUT: api/<AccountController>/changeData
        [HttpPut("changeData")]
        public async Task ChangeUserData([FromBody]User user)
        {                         
            await _userService.CangeUserDataAsync(user);
            Console.WriteLine($"user : {user.Id} - was saccesfully changed");
        }

        // DELETE: api/<AccountController>/DeleteUser/{userId}
        [HttpDelete("DeleteUser/{userId:int}")]
        public async Task DeleteUser(int userId)
        {
            await _userService.DeleteUserAsync(userId);
            Console.WriteLine($"user :id {userId} - was saccesfully deleted");

        }

    }
}
