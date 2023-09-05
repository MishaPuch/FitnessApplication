using FitnessApp.BLL.Interface;
using FitnessApp.DAL.ViewModel;
using FitnessApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreningPlanController : ControllerBase
    {
        private readonly IDaysOfDietAndExerciseService _daysOfDietAndExerciseService;
        public TreningPlanController(IDaysOfDietAndExerciseService daysOfDietAndExerciseService)
        {
            _daysOfDietAndExerciseService= daysOfDietAndExerciseService;
        }

        // GET: api/<TreningPlanController>/GetPlan/{userId:int}
        [HttpGet("GetDalyPlan/{userId:int}/{month:int}/{dayId:int}")]
        public async Task<List<FullModel>> GetDalyPlan(int userId ,int month ,int dayId)
        {
            return await _daysOfDietAndExerciseService.GetDalyPlanAsync(userId, month, dayId);
        }

        // GET: api/<TreningPlanController>/GetPlan/{userId:int}
        [HttpGet("GetUserTodaysPlan/{userId:int}")]
        public async Task<List<FullModel>> GetUserTodaysPlan(int userId)
        {
            return await _daysOfDietAndExerciseService.GetUserTodaysPlanAsync(userId);
        }

        // GET: api/<TreningPlanController>/GetAllPlans
        [HttpGet("GetAllPlans")]
        public async Task<List<FullModel>> GetAllPlans()
        {
            return await _daysOfDietAndExerciseService.GetAllPlans();
        }

        // GET: api/<TreningPlanController>/GetAllUserPlans/{userId:int}
        [HttpGet("GetAllUserPlans/{userId:int}")]
        public async Task<List<FullModel>> GetAllUserPlans(int userId)
        {
            return await _daysOfDietAndExerciseService.GetAllUserPlansAsync(userId);
        }
        // POST api/<TreningPlanController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<TreningPlanController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<TreningPlanController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
