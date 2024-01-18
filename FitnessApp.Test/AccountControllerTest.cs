using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.BLL.DI_Service;
using FitnessApp.BLL.GetModels;
using FitnessApp.BLL.Interface;
using FitnessApp.Controllers;
using FitnessApp.DAL.Helpers;
using FitnessApp.DAL.Models;
using FitnessApp.DAL.ViewModel;
using FitnessApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class AccountControllerTests
{
    private readonly Mock<IUserService> userServiceMock;
    private readonly Mock<ITrainingAndDietScheduleService> trainingAndDietScheduleMock;
    private readonly Mock<IDietService> dietServiceMock;
    private readonly Mock<ITreningService> treningServiceMock;
    private readonly Mock<IRoleService> roleServiceMock;
    private readonly Mock<ITreningPlanService> treningPlanServiceMock;
    private readonly Mock<IVereficationUserService> vereficationUserServiceMock;
    private readonly Mock<QueueHelper> queueHelperMock;

    public AccountControllerTests()
    {
        userServiceMock = new Mock<IUserService>();
        trainingAndDietScheduleMock = new Mock<ITrainingAndDietScheduleService>();
        dietServiceMock = new Mock<IDietService>();
        treningServiceMock = new Mock<ITreningService>();
        roleServiceMock = new Mock<IRoleService>();
        treningPlanServiceMock = new Mock<ITreningPlanService>();
        vereficationUserServiceMock = new Mock<IVereficationUserService>();
        queueHelperMock = new Mock<QueueHelper>();
    }

    [Fact]
    public async Task GetUsers_ReturnsListOfUsers()
    {
        // Arrange
        userServiceMock.Setup(x => x.GetAllUsersAsync())
            .ReturnsAsync(new List<User>());
        var controller = new AccountController(userServiceMock.Object, trainingAndDietScheduleMock.Object, dietServiceMock.Object, treningServiceMock.Object, roleServiceMock.Object, treningPlanServiceMock.Object, vereficationUserServiceMock.Object , queueHelperMock.Object);

        // Act
        var result = await controller.GetUsers();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<User>>(result);
        // Add more specific assertions based on your requirements
    }

    [Fact]
    public async Task GetUser_ReturnsUser()
    {
        // Arrange
        var userId = 1;
        var user = new User { Id = userId, /* Set other properties */ };
        userServiceMock.Setup(x => x.GetUserByIdAsync(userId)).ReturnsAsync(user);
        var controller = new AccountController(userServiceMock.Object, trainingAndDietScheduleMock.Object, dietServiceMock.Object, treningServiceMock.Object, roleServiceMock.Object, treningPlanServiceMock.Object, vereficationUserServiceMock.Object, queueHelperMock.Object);

        // Act
        var result = await controller.GetUser(userId);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<User>(result);
        // Add more specific assertions based on your requirements
    }

    [Fact]
    public async Task GetUserVerification_ReturnsFullModelList()
    {
        // Arrange
        var userEmail = "test@example.com";
        var password = "password";
        var user = new User
        {
            Id = 1,
            UserName = "JohnDoe",
            UserEmail = "john.doe@example.com",
            IsEmailConfirmed = true,
            Password = "hashedPassword", // Ideally, this should be a securely hashed password
            Sex = "Male",
            Age = 25,
            RestTime = 8,
            CalorificValue = 2000,
            DateOFLastPayment = DateTime.Now.AddDays(-30), // Assuming the last payment was 30 days ago
            TreningPlanId = 2,
            TreningPlan = new TreningPlan { /* Set TreningPlan properties here */ },
            RoleId = 1,
            Role = new Role { /* Set Role properties here */ },
            Avatar = "path/to/avatar.jpg"
        };
        userServiceMock.Setup(x => x.GetUserByEmailAndPasswordAsync(userEmail, password)).ReturnsAsync(user);
        // Assuming you have also set up the necessary dependencies for the method to execute successfully
        trainingAndDietScheduleMock.Setup(x => x.GetUserTodaysPlanAsync(It.IsAny<int>())).ReturnsAsync(new List<FullModel> { /* Set FullModel properties here */ });
        var controller = new AccountController(userServiceMock.Object, trainingAndDietScheduleMock.Object, dietServiceMock.Object, treningServiceMock.Object, roleServiceMock.Object, treningPlanServiceMock.Object, vereficationUserServiceMock.Object, queueHelperMock.Object);

        // Act
        var result = await controller.GetUserVerification(userEmail, password);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<FullModel>>(result);
        // Add more specific assertions based on your requirements
    }


    [Fact]
    public async Task Register_ReturnsOkResult()
    {
        // Arrange
        var getCreatingUser = new GetUser { /* Set GetUser properties here */ };
        var user = new User { /* Set user properties here */ };
        userServiceMock.Setup(x => x.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync((User)null);
        userServiceMock.Setup(x => x.CreateUserAsync(It.IsAny<User>())).ReturnsAsync(user);
        var controller = new AccountController(userServiceMock.Object, trainingAndDietScheduleMock.Object, dietServiceMock.Object, treningServiceMock.Object, roleServiceMock.Object, treningPlanServiceMock.Object, vereficationUserServiceMock.Object, queueHelperMock.Object);

        // Act
        var result = await controller.Register(getCreatingUser);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        // Add more specific assertions based on your requirements
    }

    [Fact]
    public async Task ChangeUserData_ReturnsNoContent()
    {
        // Arrange
        var getCreatingUser = new GetUser { /* Set GetUser properties here */ };
        var user = new User { /* Set user properties here */ };
        userServiceMock.Setup(x => x.CangeUserDataAsync(It.IsAny<User>()));
        var controller = new AccountController(userServiceMock.Object, trainingAndDietScheduleMock.Object, dietServiceMock.Object, treningServiceMock.Object, roleServiceMock.Object, treningPlanServiceMock.Object, vereficationUserServiceMock.Object, queueHelperMock.Object);

        // Act
        await controller.ChangeUserData(getCreatingUser);

    }

    [Fact]
    public async Task DeleteUser_ReturnsNoContent()
    {
        // Arrange
        var userId = 1;
        userServiceMock.Setup(x => x.DeleteUserAsync(userId)).Returns(Task.CompletedTask); // Make sure to return a completed task
        var controller = new AccountController(userServiceMock.Object, trainingAndDietScheduleMock.Object, dietServiceMock.Object, treningServiceMock.Object, roleServiceMock.Object, treningPlanServiceMock.Object, vereficationUserServiceMock.Object, queueHelperMock.Object);

        // Act
        await controller.DeleteUser(userId);

        // Assert
        // No need to assert on the result, as it is void
    }

}
