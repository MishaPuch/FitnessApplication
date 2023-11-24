using Castle.Components.DictionaryAdapter.Xml;
using FitnessApp.BLL.DI_Service;
using FitnessApp.BLL.GetModels;
using FitnessApp.BLL.Interface;
using FitnessApp.Controllers;
using FitnessApp.DAL.Helpers;
using FitnessApp.DAL.Models;
using FitnessApp.DAL.ViewModel;
using FitnessApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppTest.xUnit
{
    public class AccountTest
    {
        private readonly Mock<IUserService> userServiceMock;
        private readonly Mock<ITrainingAndDietSchedule> trainingAndDietScheduleMock;
        private readonly Mock<IDietService> dietServiceMock;
        private readonly Mock<ITreningService> treningServiceMock;
        private readonly Mock<IRoleService> roleServiceMock;
        private readonly Mock<ITreningPlanService> treningPlanServiceMock;
        private readonly Mock<IVereficationUserService> vereficationUserServiceMock;
        private readonly Mock<QueueHelper> queueHelperMock;

        public AccountTest()
        {
            userServiceMock = new Mock<IUserService>();
            trainingAndDietScheduleMock = new Mock<ITrainingAndDietSchedule>();
            dietServiceMock = new Mock<IDietService>();
            treningServiceMock = new Mock<ITreningService>();
            roleServiceMock = new Mock<IRoleService>();
            treningPlanServiceMock = new Mock<ITreningPlanService>();
            vereficationUserServiceMock= new Mock<IVereficationUserService>();
            queueHelperMock = new Mock<QueueHelper>();
        }

        [Fact]
        public async Task GetUsers_ReturnsListOfUsers()
        {
            userServiceMock.Setup(service => service.GetAllUsersAsync()).ReturnsAsync(new List<User>());
            var controller = new AccountController(userServiceMock.Object, null, null, null, null, null, null, null);
            var result = await controller.GetUsers();
            Assert.NotNull(result);
            Assert.IsType<List<User>>(result);
        }

        [Fact]
        public async void GetUser_ReturnUserById()
        {
            userServiceMock.Setup(service => service.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(new User());

            var controller = new AccountController(userServiceMock.Object, null, null, null, null, null, null, null);

            var result = await controller.GetUser(1);

            var actionResult = Assert.IsType<User>(result);
            Assert.NotNull(actionResult);
        }
        [Fact]
        public async Task GetUserVerification_ReturnsFullModelList()
        {
            // Arrange
            var userEmail = "mpuczkowskij@gmail.com";
            var password = "123";

            userServiceMock.Setup(x => x.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new User());
            trainingAndDietScheduleMock.Setup(x => x.GetUserTodaysPlanAsync(It.IsAny<int>())).ReturnsAsync(new List<FullModel>());

            var controller = new AccountController(userServiceMock.Object, trainingAndDietScheduleMock.Object, null, null, null, null, null, queueHelperMock.Object);

            try
            {
                // Act
                var result = await controller.GetUserVerification(userEmail, password);

                // Assert
                Assert.NotNull(result);
                Assert.IsType<List<FullModel>>(result);

                // Verify that GetUserByEmailAndPasswordAsync was called with the expected parameters
                userServiceMock.Verify(x => x.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()));
            }
            catch (Exception ex)
            {
                // Добавим вывод в консоль для отслеживания ошибки
                Console.WriteLine($"Exception: {ex}");
                throw; // Перебрасываем исключение, чтобы тест был отмечен как не пройденный
            }
        }


        [Fact]
        public async Task Register_ReturnsOkObjectResult_WhenUserIsCreated()
        {
            // Arrange
            var accountController = new AccountController(
                userServiceMock.Object,
                trainingAndDietScheduleMock.Object,
                dietServiceMock.Object,
                treningServiceMock.Object,
                roleServiceMock.Object,
                treningPlanServiceMock.Object,
                vereficationUserServiceMock.Object,
                queueHelperMock.Object
            );

            var createUser = new GetUser
            {
                UserName = "JohnDoe",
                UserEmail = "john.doe@example.com",
                Password = "securePassword",
                Sex = "Male",
                Age = 25,
                RestTime = 8,
                CalorificValue = 2000,
                DateOFLastPayment = DateTime.Now,
                TreningPlanId = 1,
                RoleId = 1,

            };
            userServiceMock.Setup(x => x.CreateUserAsync(It.IsAny<User>())).ReturnsAsync((User creatingUser) =>
            {
                creatingUser.Id = 1; // Пример установки значения для Id
                creatingUser.UserName = createUser.UserName;
                creatingUser.UserEmail = createUser.UserEmail;
                creatingUser.Password = createUser.Password;
                creatingUser.Sex = createUser.Sex;
                creatingUser.Age = createUser.Age;
                creatingUser.RestTime = createUser.RestTime;
                creatingUser.CalorificValue = createUser.CalorificValue;
                creatingUser.DateOFLastPayment = createUser.DateOFLastPayment;
                creatingUser.TreningPlanId = createUser.TreningPlanId;

                TreningPlan treningPlan = new TreningPlan()
                {
                    TreningPlanValue = "kniunv"
                };
                creatingUser.TreningPlan = treningPlan;

                creatingUser.RoleId = createUser.RoleId;
                Role role = new Role()
                {
                    RoleName = "bfisdfn"
                };
                creatingUser.Role = role;

                return creatingUser;
            });

            userServiceMock.Setup(x => x.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync((User)null);
            userServiceMock.Setup(x => x.CreateUserAsync(It.IsAny<User>())).ReturnsAsync(new User());
            trainingAndDietScheduleMock.Setup(x => x.MakeAMonthInTreningAndSchedulesAsync(It.IsAny<int>(), It.IsAny<DateTime>())).ReturnsAsync(new List<TreningAndDietSchedule>());
            dietServiceMock.Setup(x => x.MakeDietForAMonthAsync(It.IsAny<List<TreningAndDietSchedule>>())).ReturnsAsync(new List<Diet>());
            treningServiceMock.Setup(x => x.MakeTreningForAMonthAsync(It.IsAny<List<TreningAndDietSchedule>>())).ReturnsAsync(new List<Trening>());
            treningPlanServiceMock.Setup(x => x.GetTreningPlanByIdAsync(It.IsAny<int>())).ReturnsAsync(new TreningPlan());
            roleServiceMock.Setup(x=>x.GetByUserIdAsync(It.IsAny<int>())).ReturnsAsync(new Role());
            queueHelperMock.Setup(x => x.EmailVereficationAsync(It.IsAny<User>()));

            try 
            {
                var result = await accountController.Register(createUser);

                 var returnValue = Assert.IsType<List<FullModel>>(result);

                Assert.NotNull(returnValue);
            }
            catch (Exception ex)
            {
                // Добавим вывод в консоль для отслеживания ошибки
                Console.WriteLine($"Exception: {ex}");
                throw; // Перебрасываем исключение, чтобы тест был отмечен как не пройденный
            }
        }
    }
}

