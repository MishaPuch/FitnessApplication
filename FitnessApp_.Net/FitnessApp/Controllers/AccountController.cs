﻿using FitnessApp.BLL.DI_Service;
using FitnessApp.BLL.Interface;
using FitnessApp.BLL.Services;
using FitnessApp.BLL.Services.FileServices;
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
        private readonly IUserService _userService;
        private readonly ITrainingAndDietSchedule _trainingAndDietSchedule;
        private readonly IDietService _dietService;
        private readonly ITreningService _treningService;
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public AccountController(
            IUserService userService,
            ITrainingAndDietSchedule trainingAndDietSchedule,
            IDietService dietService,
            ITreningService treningService,
            MealFileService mealFileService,
            UserFileService userFileService
            )
        {
            _userService = userService;
            _trainingAndDietSchedule = trainingAndDietSchedule;
            _dietService = dietService;
            _treningService = treningService;
            _mealFileService = mealFileService;
            _userFileService = userFileService;
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
            {
                return await _trainingAndDietSchedule.GetUserTodaysPlanAsync(user.Id);
                Logger.Info($"user was found : { user }");
            }
            else
            {
                Logger.Info($"user was not found : {user}");
                return new List<FullModel>();
            }
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> Register([FromBody] User creatingUser/*, [FromForm] IFormFile file*/)
        {
            try
            {
                User checkingUser = await _userService.GetUserByEmailAsync(creatingUser.UserEmail);
                if (checkingUser != null)
                {
                    return Ok(await _trainingAndDietSchedule.GetUserTodaysPlanAsync(checkingUser.Id));
                }
                else
                {
                    User user = await _userService.CreateUserAsync(creatingUser);
                    /*if (file != null)
                    {
                        var result = await _uxserFileService.UploadFile(file, user);
                    }*/
                    var treningAndDietSchedule = await _trainingAndDietSchedule.MakeAMonthInTreningAndSchedulesAsync(user.Id, user.DateOFLastPayment);
                    var dietForAMonth = await _dietService.MakeDietForAMonthAsync(treningAndDietSchedule);
                    var treningForAMonth = await _treningService.MakeTreningForAMonthAsync(treningAndDietSchedule);

                    return Ok(await _trainingAndDietSchedule.GetUserTodaysPlanAsync(user.Id));
                }
            }
            catch (Exception ex)
            {
                // Здесь вы можете записать сообщение об ошибке в логи или вернуть его как часть ответа для отладки
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        // PUT: api/<AccountController>/changeData
        [HttpPut("changeData")]
        public async Task ChangeUserData([FromBody] User user)
        {
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
        [HttpGet("GetAllFotos")]
        public async Task<IActionResult> ListOfBlobs()
        {
            var result = await _mealFileService.ListOfMealBlobsAsync();

            return Ok(result);
        }
        [HttpPost("PostTheMealFoto")]
        public async Task<IActionResult> UploadMealBlob(IFormFile file)
        {
            var result = await _mealFileService.UploadFile(file);

            return Ok(result);
        }
        [HttpPost("PostTheAvatarFoto")]
        public async Task<IActionResult> UploadAvatarBlob(IFormFile file)
        {
            var result = await _userFileService.UploadFile(file , await _userService.GetUserByIdAsync(96));
            
            return Ok(result);
        }
        [HttpGet("DownloadTheFoto")]
        public async Task<IActionResult> DownloadTheBlob(string fileName)
        {
            var result = await _mealFileService.DownloadFileAsync(fileName);

            return Ok(result);
        }
        [HttpDelete("DeleteTheFoto")]
        public async Task<IActionResult> DeleteTheBlob(string fileName)
        {
            var result = await _mealFileService.DeleteFileAsync(fileName);

            return Ok(result);
        }

    }
}
