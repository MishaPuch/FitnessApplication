﻿using FitnessApp.BLL.DI_Service;
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

        public AccountController(
            IUserService userService,
            ITrainingAndDietSchedule trainingAndDietSchedule,
            IDietService dietService
            ) 
        { 
            _userService = userService;
            _trainingAndDietSchedule = trainingAndDietSchedule;
            _dietService=dietService;
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
        public async Task Register([FromBody] User user)
        {
             
            User createdUser= await _userService.CreateUserAsync(user);
            var treningAndDietSchedule = await _trainingAndDietSchedule.MakeAMonthInTreningAndSchedulesAsync(createdUser.Id, createdUser.DateOFLastPayment);
            var dietForAMonth = await _dietService.MakeDietForAMonthAsync(treningAndDietSchedule);

            Console.WriteLine($"user : {user.Id} - was saccesfully created");
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
