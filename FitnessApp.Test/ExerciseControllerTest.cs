using FitnessApp.BLL.GetModels;
using FitnessApp.BLL.Interface;
using FitnessApp.Controllers;
using FitnessApp.DAL.Models;
using FitnessApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Test
{
    public class ExerciseControllerTest
    {
        private readonly Mock<ITypeOfMuscleGroupService> typeOfMuscleGroupServiceMock;
        private readonly Mock<ITypeOfTreningService> typeOfTreningServiceMock;
        private readonly Mock<IExerciseService> exerciseServiceMock;
        public ExerciseControllerTest()
        {
            typeOfMuscleGroupServiceMock = new Mock<ITypeOfMuscleGroupService>();
            typeOfTreningServiceMock=new Mock<ITypeOfTreningService>();
            exerciseServiceMock= new Mock<IExerciseService>();  
        }
        [Fact]
        public async Task GetAllExercises()
        {
            exerciseServiceMock.Setup(x => x.GetAllExercisesAsync()).ReturnsAsync(new List<Exercise>());
            var exerciseController = new ExerciseController(exerciseServiceMock.Object,null,null);

            var result =await exerciseController.GetAllExercises();

            Assert.NotNull(result);
            Assert.IsType<List<Exercise>>(result);
        }
        [Fact]
        public async Task GetExerciseById()
        {
            int id=1;
            exerciseServiceMock.Setup(x => x.GetExerciseByIdAsync(It.IsAny<int>())).ReturnsAsync(new Exercise());
            var exerciseController = new ExerciseController(exerciseServiceMock.Object, null,null);

            var result = await exerciseController.GetExerciseById(id);

            Assert.NotNull(result);
            Assert.IsType<Exercise>(result);
        }
        [Fact]
        public async Task CreateExercise()
        {
            GetExercise getExercise = new GetExercise
            {
                Id = 1,
                ExerciseName = "Push-up",
                ExerciseDescription = "A bodyweight exercise that works the chest, shoulders, and triceps.",
                ExerciseVideo = "https://www.example.com/push-up-video",
                MuscleGroupId = 2, // Assuming 2 is the ID for the relevant muscle group
                TypeOfTreningId = 3, // Assuming 3 is the ID for the relevant training type
            };
            Exercise myExercise = new Exercise
            {
                Id = 1,
                ExerciseName = "Push-up",
                ExerciseDescription = "A bodyweight exercise that works the chest, shoulders, and triceps.",
                ExerciseVideo = "https://www.example.com/push-up-video",
                MuscleGroupId = 2, // Assuming 2 is the ID for the relevant muscle group
                MuscleGroup = new TypeOfMuscleGroup {  NameMuscleGroup = "Upper Body" }, // Creating a TypeOfMuscleGroup instance
                TypeOfTreningId = 3, // Assuming 3 is the ID for the relevant training type
                TypeOfTrening = new TypeOfTrening { TypeOfTreningValue= "Strength Training" } // Creating a TypeOfTrening instance
            };

            exerciseServiceMock.Setup(x => x.CreateExerciseAsync(It.IsAny<Exercise>()));
            typeOfMuscleGroupServiceMock.Setup(x => x.GetTypeOfMuscleGroupByIdAsync(It.IsAny<int>())).ReturnsAsync(new TypeOfMuscleGroup());
            typeOfTreningServiceMock.Setup(x => x.GetTypeOfTreningByIdAsync(It.IsAny<int>())).ReturnsAsync(new TypeOfTrening());



            var exerciseController = new ExerciseController(exerciseServiceMock.Object, typeOfMuscleGroupServiceMock.Object, typeOfTreningServiceMock.Object);

            await exerciseController.CreateExercise(getExercise);
        }
        [Fact]
        public async Task UpdateExercise()
        {
            GetExercise getExercise = new GetExercise
            {
                Id = 1,
                ExerciseName = "Push-up",
                ExerciseDescription = "A bodyweight exercise that works the chest, shoulders, and triceps.",
                ExerciseVideo = "https://www.example.com/push-up-video",
                MuscleGroupId = 2, // Assuming 2 is the ID for the relevant muscle group
                TypeOfTreningId = 3, // Assuming 3 is the ID for the relevant training type
            };
            Exercise myExercise = new Exercise
            {
                Id = 1,
                ExerciseName = "Push-up",
                ExerciseDescription = "A bodyweight exercise that works the chest, shoulders, and triceps.",
                ExerciseVideo = "https://www.example.com/push-up-video",
                MuscleGroupId = 2, // Assuming 2 is the ID for the relevant muscle group
                MuscleGroup = new TypeOfMuscleGroup { NameMuscleGroup = "Upper Body" }, // Creating a TypeOfMuscleGroup instance
                TypeOfTreningId = 3, // Assuming 3 is the ID for the relevant training type
                TypeOfTrening = new TypeOfTrening { TypeOfTreningValue = "Strength Training" } // Creating a TypeOfTrening instance
            };

            exerciseServiceMock.Setup(x => x.UpdateExerciseAsync(It.IsAny<Exercise>())).ReturnsAsync(new Exercise());
            typeOfMuscleGroupServiceMock.Setup(x => x.GetTypeOfMuscleGroupByIdAsync(It.IsAny<int>())).ReturnsAsync(new TypeOfMuscleGroup());
            typeOfTreningServiceMock.Setup(x => x.GetTypeOfTreningByIdAsync(It.IsAny<int>())).ReturnsAsync(new TypeOfTrening());

            var exerciseController = new ExerciseController(exerciseServiceMock.Object, typeOfMuscleGroupServiceMock.Object, typeOfTreningServiceMock.Object);

            var result= await exerciseController.UpdateExercise(getExercise);

            Assert.NotNull(result);
            Assert.IsType<Exercise>(result);

        }
        [Fact]
        public async Task DeleteExercise()
        {
            int id = 1;

            exerciseServiceMock.Setup(x => x.DeleteExerciseAsync(It.IsAny<int>()));
            var exerciseController = new ExerciseController(exerciseServiceMock.Object, null, null);

            await exerciseController.DeleteExercise(id);

            exerciseServiceMock.Verify(x => x.DeleteExerciseAsync(id), Times.Once);
        }

    }
}
