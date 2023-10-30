using FitnessApp.BLL.DI_Service;
using FitnessApp.BLL.Services;
using FitnessApp.BLL.Services.FileServices;
using FitnessApp.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp.Formats.Jpeg;
using static System.Net.Mime.MediaTypeNames;
using Image = SixLabors.ImageSharp.Image;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly MealFileService _mealFileService;
        private readonly UserFileService _userFileService;
        private readonly IUserService _userService;

        public ImagesController(
            MealFileService mealFileService,
            UserFileService userFileService,
            IUserService userService
            )
        {
            _mealFileService = mealFileService;
            _userFileService = userFileService;
            _userService = userService;
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
/*
            using (var imageStream = new MemoryStream())
            {
                await file.CopyToAsync(imageStream);
                imageStream.Seek(0, SeekOrigin.Begin);

                using (var image = Image.Load(imageStream))
                {
                    using (var formattedImageStream = new MemoryStream())
                    {
                        image.SaveAsJpeg(formattedImageStream, new JpegEncoder()); // Сохранить как JPEG
                        formattedImageStream.Seek(0, SeekOrigin.Begin);

                        // Теперь загрузите форматированный поток данных в хранилище
                        var result = await _userFileService.UploadFile(formattedImageStream, user);
                    }
                }
            }*/

            return Ok("Image uploaded and processed.");
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
