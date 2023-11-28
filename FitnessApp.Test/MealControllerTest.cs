using FitnessApp.BLL.GetModels;
using FitnessApp.BLL.Interface;
using FitnessApp.Controllers;
using FitnessApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Test
{
    public class MealControllerTest
    {
        private readonly Mock<IMealService> mealServiceMock;
        private readonly Mock<ITypeOfMealService> typeOfMealServiceMock;

        public MealControllerTest()
        {
            mealServiceMock = new Mock<IMealService>();
            typeOfMealServiceMock = new Mock<ITypeOfMealService>();   
        }

        [Fact]
        public async Task GetAllMealAsync_ShouldReturnListOfMeals()
        {
            // Arrange
            mealServiceMock.Setup(x => x.GetAllMealsAsync()).ReturnsAsync(new List<Meal>());

            var controller = new MealController(mealServiceMock.Object,null);

            // Act
            var result = await controller.GetAllMealAsync();

            // Assert
            var meals = Assert.IsType<List<Meal>>(result);
            Assert.Empty(meals);  // Проверяем, что список блюд пуст
        }

        [Fact]
        public async Task GetMealByIdAsync_ShouldReturnMeal()
        {
            // Arrange
            int mealId = 1;
            var expectedMeal = new Meal();  
            mealServiceMock.Setup(x => x.GetMealByIdAsync(mealId)).ReturnsAsync(expectedMeal);

            var controller = new MealController(mealServiceMock.Object, null);

            // Act
            var result = await controller.GetMealByIdAsync(mealId);

            // Assert
            var meal = Assert.IsType<Meal>(result);
            Assert.Equal(expectedMeal, meal);  
        }
        [Fact]
        public async Task DeleteMeal()
        {
            int mealId = 1;
            mealServiceMock.Setup(x => x.DeleteMealAsync(mealId));

            var controller = new MealController(mealServiceMock.Object, null);

            // Act
            var result = await controller.DeleteMeal(mealId);

            // Assert
            Assert.IsType<OkResult>(result);
       }
        [Fact]
        public async Task UpdateMealAsync()
        {
            // Arrange
            var meal = new GetMeal
            {
                Id = 1,
                FoodName = "Chicken Salad",
                FoodIngredients = "Chicken, lettuce, tomatoes, cucumbers, dressing",
                FoodInstructions = "1. Grill the chicken. 2. Chop the vegetables. 3. Mix everything in a bowl. 4. Add dressing.",
                Foto = "chicken_salad.jpg",
                Protein = 25.5,
                Fat = 12.3,
                Carbon = 15.8,
                CalorificOfMeal = 350.5,
                TypeOfMealId = 3
            };

            var updatedMeal = new Meal
            {
                Id = 1,
                FoodName = "Chicken Salad",
                FoodIngredients = "Chicken, Lettuce, Tomato, Dressing",
                FoodInstructions = "Mix all ingredients in a bowl.",
                Foto = "chicken_salad.jpg",
                Protein = 20.5,
                Fat = 10.2,
                Carbon = 15.8,
                CalorificOfMeal = 250.5,
                TypeOfMealId = 1,
                TypeOfMeal = new TypeOfMeal
                {
                    Id = 1,
                    NameFoodType = "Lunch"
                }
            };

            typeOfMealServiceMock.Setup(x => x.GetTypeOfMealByIdAsync(meal.TypeOfMealId)).ReturnsAsync(new TypeOfMeal());
            mealServiceMock.Setup(x => x.UpdateMealAsync(It.IsAny<Meal>())).ReturnsAsync(updatedMeal);

            var controller = new MealController(mealServiceMock.Object, typeOfMealServiceMock.Object);

            // Act
            var result = await controller.UpdateMealAsync(meal);

            // Assert
            var resultMeal = Assert.IsType<Meal>(result);
            Assert.Equal(updatedMeal, resultMeal);
        }
        [Fact]
        public async Task CreateMealAsync()
        {
            var meal = new GetMeal
            {
                Id = 1,
                FoodName = "Chicken Salad",
                FoodIngredients = "Chicken, lettuce, tomatoes, cucumbers, dressing",
                FoodInstructions = "1. Grill the chicken. 2. Chop the vegetables. 3. Mix everything in a bowl. 4. Add dressing.",
                Foto = "chicken_salad.jpg",
                Protein = 25.5,
                Fat = 12.3,
                Carbon = 15.8,
                CalorificOfMeal = 350.5,
                TypeOfMealId = 3
            };

            var updatedMeal = new Meal
            {
                Id = 1,
                FoodName = "Chicken Salad",
                FoodIngredients = "Chicken, Lettuce, Tomato, Dressing",
                FoodInstructions = "Mix all ingredients in a bowl.",
                Foto = "chicken_salad.jpg",
                Protein = 20.5,
                Fat = 10.2,
                Carbon = 15.8,
                CalorificOfMeal = 250.5,
                TypeOfMealId = 1,
                TypeOfMeal = new TypeOfMeal
                {
                    Id = 1,
                    NameFoodType = "Lunch"
                }
            };
            typeOfMealServiceMock.Setup(x => x.GetTypeOfMealByIdAsync(meal.TypeOfMealId)).ReturnsAsync(new TypeOfMeal());
            mealServiceMock.Setup(x => x.CreateMealAsync(It.IsAny<Meal>()));

            var controller = new MealController(mealServiceMock.Object, typeOfMealServiceMock.Object);

            // Act
            var result = await controller.CreateMealAsync(meal);

            // Assert
            var resultMeal = Assert.IsType<OkObjectResult>(result);
            //Assert.Equal(updatedMeal, resultMeal);

            //< ActionResult >

        }


    }
}
