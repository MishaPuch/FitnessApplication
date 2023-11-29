using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.BLL.Interface;
using FitnessApp.Controllers;
using FitnessApp.DAL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FitnessApp.Test
{
    public class TreningPlanControllerTest
    {
        private readonly Mock<ITrainingAndDietSchedule> trainingAndDietScheduleMock;
        private readonly TreningPlanController controller;

        public TreningPlanControllerTest()
        {
            trainingAndDietScheduleMock = new Mock<ITrainingAndDietSchedule>();
            controller = new TreningPlanController(trainingAndDietScheduleMock.Object);
        }

        [Fact]
        public async Task GetDalyPlan_ReturnsOkResult()
        {
            // Arrange
            int userId = 1;
            DateTime day = DateTime.Now;

            // Mocking the dependency
            trainingAndDietScheduleMock
                .Setup(repo => repo.GetDalyPlanAsync(userId, It.IsAny<DateTime>()))
                .ReturnsAsync(new List<FullModel>()); // Replace with your expected result

            // Act
            var result = await controller.GetDalyPlan(userId, day);

            // Assert
            Assert.IsType<List<FullModel>>(result);
        }

        [Fact]
        public async Task GetUserTodaysPlan_ReturnsOkResult()
        {
            // Arrange
            int userId = 1;

            // Mocking the dependency
            trainingAndDietScheduleMock
                .Setup(repo => repo.GetUserTodaysPlanAsync(userId))
                .ReturnsAsync(new List<FullModel>()); // Replace with your expected result

            // Act
            var result = await controller.GetUserTodaysPlan(userId);

            // Assert
            Assert.IsType<List<FullModel>>(result);
        }

        [Fact]
        public async Task GetAllPlans_ReturnsOkResult()
        {
            // Mocking the dependency
            trainingAndDietScheduleMock
                .Setup(repo => repo.GetAllPlans())
                .ReturnsAsync(new List<FullModel>()); // Replace with your expected result

            // Act
            var result = await controller.GetAllPlans();

            // Assert
            Assert.IsType<List<FullModel>>(result);
        }

        [Fact]
        public async Task GetAllUserPlans_ReturnsOkResult()
        {
            // Arrange
            int userId = 1;

            // Mocking the dependency
            trainingAndDietScheduleMock
                .Setup(repo => repo.GetAllUserPlansAsync(userId))
                .ReturnsAsync(new List<FullModel>()); // Replace with your expected result

            // Act
            var result = await controller.GetAllUserPlans(userId);

            // Assert
            Assert.IsType<List<FullModel>>(result);
        }
    }
}
