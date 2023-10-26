using FitnessApp.BLL.GetModels;
using FitnessApp.BLL.Interface;
using FitnessApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ITypeOfMuscleGroupService _typeOfMuscleGroupService;
        private readonly ITypeOfTreningService _typeOfTreningService;
        private readonly IExerciseService _exerciseService;
        public ExerciseController(IExerciseService exerciseService,
            ITypeOfMuscleGroupService typeOfMuscleGroupService, 
            ITypeOfTreningService typeOfTreningService
            )
        {
            _exerciseService = exerciseService;
            _typeOfMuscleGroupService = typeOfMuscleGroupService;
            _typeOfTreningService= typeOfTreningService;
        }

        // GET: api/<TreningController>
        [HttpGet("getAllExercises")]
        public async Task<List<Exercise>> GetAllExercises()
        {
            return await _exerciseService.GetAllExercisesAsync();
        }

        // GET api/<TreningController>/5
        [HttpGet("getExerciseById/{id:int}")]
        public async Task<Exercise> GetExerciseById(int id)
        {
            return await _exerciseService.GetExerciseByIdAsync(id);
        }

        // POST api/<TreningController>
        [HttpPost("createExercise")]
        public async Task CreateExercise([FromBody] GetExercise getExercise)
        {
            Exercise exercise = new Exercise()
            {
                ExerciseName = getExercise.ExerciseName,
                ExerciseDescription = getExercise.ExerciseDescription,
                ExerciseVideo = getExercise.ExerciseVideo,
                MuscleGroupId = getExercise.MuscleGroupId,
                MuscleGroup = await _typeOfMuscleGroupService.GetTypeOfMuscleGroupByIdAsync(getExercise.MuscleGroupId),
                TypeOfTreningId=getExercise.TypeOfTreningId,
                TypeOfTrening=await _typeOfTreningService.GetTypeOfTreningByIdAsync(getExercise.TypeOfTreningId)
                
            };
            await _exerciseService.CreateExerciseAsync(exercise);
        }

        // PUT api/<TreningController>/5
        [HttpPut("update-exercise")]
        public async Task<Exercise> UpdateExercise([FromBody] GetExercise getExercise)
        {
            Exercise exercise = new Exercise()
            {
                ExerciseName = getExercise.ExerciseName,
                ExerciseDescription = getExercise.ExerciseDescription,
                ExerciseVideo = getExercise.ExerciseVideo,
                MuscleGroupId = getExercise.MuscleGroupId,
                MuscleGroup = await _typeOfMuscleGroupService.GetTypeOfMuscleGroupByIdAsync(getExercise.MuscleGroupId),
                TypeOfTreningId = getExercise.TypeOfTreningId,
                TypeOfTrening = await _typeOfTreningService.GetTypeOfTreningByIdAsync(getExercise.TypeOfTreningId)

            };
            return await _exerciseService.UpdateExerciseAsync(exercise);
        }

        // DELETE api/<TreningController>/5
        [HttpDelete("delete-exercise/{id:int}")]
        public async Task DeleteExercise(int id)
        {
            await _exerciseService.DeleteExerciseAsync(id);
        }
    }
}
