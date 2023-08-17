using FitnessApp.BLL.DI_Service;
using FitnessApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;
        public AccountController(IUserService userService) 
        { 
            this.userService = userService;
        }
        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await userService.GetAllUsersAsync();
        }
        [HttpGet("user/{id:int}")]
        public async Task<User> GetUser(int id)
        {
            return await userService.GetUserByIdAsync(id);
        }
        [HttpGet("user/{userEmail}/{password}")]
        public async Task<User> GetUserVErification(string userEmail, string password)
        {
            return await userService.GetUserByEmailAndPasswordAsync(userEmail , password);
        }
        [HttpPost]
        public async Task Register([FromBody] User user)
        {
            /*
                // Проверка наличия обязательных полей (Username, Email, Password) и других проверок
                if (string.IsNullOrEmpty(user.userName) || string.IsNullOrEmpty(user.userEmail) || string.IsNullOrEmpty(user.password))
                {
                    return BadRequest("Invalid user data");
                }

                // Проверка наличия пользователя с таким же именем или электронной почтой
                if (_users.Any(u => u.Username == user.Username || u.Email == user.Email))
                {
                    return Conflict("Username or Email already exists");
                }
            */
            // Здесь обычно выполняется хеширование пароля перед сохранением в базу данных
            // Важно не хранить пароли в открытом виде

            // Сохранение пользователя в базу данных или коллекцию

            await userService.CreateUserAsync(user);
            Console.WriteLine($"user : {user.Id} - was saccesfully created");
        }
        [HttpPut("changeData")]
        public async Task ChangeUserData([FromBody]User user)
        {                         
            await userService.CangeUserDataAsync(user);
            Console.WriteLine($"user : {user.Id} - was saccesfully changed");
        }
        [HttpDelete("DeleteUser/{id:int}")]
        public async Task DeleteUser(int id)
        {
            await userService.DeleteUserAsync(id);
            Console.WriteLine($"user :id {id} - was saccesfully deleted");

        }

    }
}
