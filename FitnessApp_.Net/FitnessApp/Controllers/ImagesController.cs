using FitnessApp.BLL.DI_Service;
using FitnessApp.BLL.Interface;
using FitnessApp.BLL.Interface.FileServiceInterface;
using FitnessApp.BLL.Services;
using FitnessApp.BLL.Services.FileServices;
using FitnessApp.DAL.Models;
using FitnessApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;
using Image = SixLabors.ImageSharp.Image;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMealFileService _mealFileService;
        private readonly IUserFileService _userFileService;
        private readonly ITreningFileService _treningFileService;
        private readonly IUserService _userService;
        private readonly IExerciseService _exerciseService;

        public ImagesController(
            IMealFileService mealFileService,
            IUserFileService userFileService,
            ITreningFileService treningFileService,
            IUserService userService,
            IExerciseService exerciseService
            )
        {
            _mealFileService = mealFileService;
            _userFileService = userFileService;
            _userService = userService;
            _treningFileService = treningFileService;
            _exerciseService = exerciseService;
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

        [HttpPost("PostTheAvatarFoto/{userId:int}")]
        public async Task<IActionResult> UploadAvatarBlob(int userId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            var user = await _userService.GetUserByIdAsync(userId);
            var result = await _userFileService.UploadFile(file, user);

            user.Avatar = _userFileService.MakeAvatarFileName(file,user);
            await _userService.CangeUserDataAsync(user);

            return Ok("Image uploaded and processed.");

        }
        [HttpPost("PostTheExercise/{exerciseId:int}")]
        public async Task<IActionResult> UploadExerciseBlob(int exerciseId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest();
            }
            Exercise exercise =await _exerciseService.GetExerciseByIdAsync(exerciseId);
            var result = await _treningFileService.UploadFile(file , exercise);

            exercise.ExerciseVideo = _treningFileService.MakeExerciseFileName(file, exercise);
            await _exerciseService.UpdateExerciseAsync(exercise);

            return Ok();
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
