using FitnessApp.BLL.DI_Service;
using FitnessApp.BLL.Interface;
using FitnessApp.BLL.Services.FileServices;
using FitnessApp.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FitnessApp.Test
{
    public class ImageControllerTest
    {
        private readonly Mock<MealFileService> mealFileServiceMock;
        private readonly Mock<UserFileService> userFileServiceMock;
        private readonly Mock<TreningFileService> treningFileServiceMock;
        private readonly Mock<IUserService> userServiceMock;
        private readonly Mock<IExerciseService> exerciseServiceMock;

        public ImageControllerTest()
        {
            mealFileServiceMock = new Mock<MealFileService>();
            userFileServiceMock = new Mock<UserFileService>();
            treningFileServiceMock = new Mock<TreningFileService>();
            userServiceMock = new Mock<IUserService>(); 
            exerciseServiceMock = new Mock<IExerciseService>();
        }
        [Fact]
        public async Task ListOfBlobs()
        {

        }


    }
}
