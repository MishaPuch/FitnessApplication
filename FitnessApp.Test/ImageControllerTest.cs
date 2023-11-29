using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FitnessApp.BLL.DI_Service;
using FitnessApp.BLL.Interface;
using FitnessApp.BLL.Services.FileServices;
using FitnessApp.BLL.Services;
using FitnessApp.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using FitnessApp.DAL.Models;
using FitnessApp.BLL.Interface.FileServiceInterface;
using FitnessApp.Models;

namespace FitnessApp.Test
{
    public class ImagesControllerTest
    {
        private readonly Mock<IMealFileService> mealFileServiceMock;
        private readonly Mock<IUserFileService> userFileServiceMock;
        private readonly Mock<ITreningFileService> treningFileServiceMock;
        private readonly Mock<IUserService> userServiceMock;
        private readonly Mock<IExerciseService> exerciseServiceMock;
        private readonly ImagesController controller;

        public ImagesControllerTest()
        {
            mealFileServiceMock = new Mock<IMealFileService>();
            userFileServiceMock = new Mock<IUserFileService>();
            treningFileServiceMock = new Mock<ITreningFileService>();
            userServiceMock = new Mock<IUserService>();
            exerciseServiceMock = new Mock<IExerciseService>();

            controller = new ImagesController(
                mealFileServiceMock.Object,
                userFileServiceMock.Object,
                treningFileServiceMock.Object,
                userServiceMock.Object,
                exerciseServiceMock.Object
            );
        }

        [Fact]
        public async Task ListOfBlobs_ReturnsOkResult()
        {
            mealFileServiceMock
                .Setup(service => service.ListOfMealBlobsAsync())
                .ReturnsAsync(new List<BlobDto>());

            var result = await controller.ListOfBlobs();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UploadMealBlob_ReturnsOkResult()
        {
            var fileMock = new Mock<IFormFile>();
            mealFileServiceMock
                .Setup(service => service.UploadFile(fileMock.Object))
                .ReturnsAsync(new BlobResponseDto()); 

            var result = await controller.UploadMealBlob(fileMock.Object);

            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task UploadAvatarBlob_ReturnsOkResult()
        {
            
            var userId = 1;
            var fileMock = new Mock<IFormFile>();
            var userMock = new User();

            fileMock.Setup(file => file.Length).Returns(1);

            userServiceMock.Setup(service => service.GetUserByIdAsync(userId)).ReturnsAsync(userMock);

            userFileServiceMock
                .Setup(service => service.UploadFile(fileMock.Object, userMock))
                .ReturnsAsync(new BlobResponseDto()); 

            var result = await controller.UploadAvatarBlob(userId, fileMock.Object);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UploadExerciseBlob_ReturnsOkResult()
        {
            var exerciseId = 1;
            var fileMock = new Mock<IFormFile>();

            fileMock.Setup(file => file.Length).Returns(1); 

            var exerciseMock = new Exercise(); 
            exerciseServiceMock.Setup(service => service.GetExerciseByIdAsync(exerciseId)).ReturnsAsync(exerciseMock);

            treningFileServiceMock
                .Setup(service => service.UploadFile(fileMock.Object, exerciseMock))
                .ReturnsAsync(new BlobResponseDto()); 

            exerciseServiceMock.Setup(service => service.UpdateExerciseAsync(exerciseMock))
                .ReturnsAsync(new Exercise());

            var result = await controller.UploadExerciseBlob(exerciseId, fileMock.Object);

            Assert.IsType<OkResult>(result);
        }



        [Fact]
        public async Task DownloadTheBlob_ReturnsOkResult()
        {
            var fileName = "test.jpg"; 
            mealFileServiceMock
                .Setup(service => service.DownloadFileAsync(fileName))
                .ReturnsAsync(new BlobDto()); 

            var result = await controller.DownloadTheBlob(fileName);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteTheBlob_ReturnsOkResult()
        {
            var fileName = "test.jpg"; 
            mealFileServiceMock
                .Setup(service => service.DeleteFileAsync(fileName))
                .ReturnsAsync(new BlobResponseDto()); 

            var result = await controller.DeleteTheBlob(fileName);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
