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
        private readonly IDaysOfDietAndExerciseService _daysOfDietAndExerciseService;

        public AccountController(
            IUserService userService,
            IDaysOfDietAndExerciseService daysOfDietAndExerciseService
            ) 
        { 
            _userService = userService;
            _daysOfDietAndExerciseService = daysOfDietAndExerciseService;
        }
        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await _userService.GetAllUsersAsync();
        }
        [HttpGet("user/{id:int}")]
        public async Task<User> GetUser(int id)
        {
            return await _userService.GetUserByIdAsync(id);
        }
        [HttpGet("user/{userEmail}/{password}")]
        public async Task<List<FullModel>> GetUserVerification(string userEmail, string password)
        {
            User? user = await _userService.GetUserByEmailAndPasswordAsync(userEmail, password);
            return await _daysOfDietAndExerciseService.GetUserTodaysPlanAsync(user.Id); 
        }
        [HttpPost]
        public async Task Register([FromBody] User user)
        {
            await _userService.CreateUserAsync(user);
            Console.WriteLine($"user : {user.Id} - was saccesfully created");
        }
        [HttpPut("changeData")]
        public async Task ChangeUserData([FromBody]User user)
        {                         
            await _userService.CangeUserDataAsync(user);
            Console.WriteLine($"user : {user.Id} - was saccesfully changed");
        }
        [HttpDelete("DeleteUser/{id:int}")]
        public async Task DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            Console.WriteLine($"user :id {id} - was saccesfully deleted");

        }

    }
}
