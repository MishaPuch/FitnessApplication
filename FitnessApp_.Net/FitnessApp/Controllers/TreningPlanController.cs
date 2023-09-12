using FitnessApp.BLL.Interface;
using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.ViewModel;
using FitnessApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreningPlanController : ControllerBase
    {
        private readonly ITrainingAndDietSchedule _trainingAndDietSchedule;

        public TreningPlanController(ITrainingAndDietSchedule trainingAndDietSchedule)
        {
            _trainingAndDietSchedule = trainingAndDietSchedule;
        }

        // GET: api/<TreningPlanController>/GetPlan/{userId:int}
        [HttpGet("GetDalyPlan/{userId:int}/{day:DateTime}")]
        public async Task<List<FullModel>> GetDalyPlan(int userId, DateTime day)
        {
            DateTime date = day.AddDays(1); // i made it because i got from front selected date -1 day
            var fullModel = await _trainingAndDietSchedule.GetDalyPlanAsync(userId, date.Date);
            return fullModel;
        }
    

        // GET: api/<TreningPlanController>/GetPlan/{userId:int}
        [HttpGet("GetUserTodaysPlan/{userId:int}")]
        public async Task<List<FullModel>> GetUserTodaysPlan(int userId)
        {
            return await _trainingAndDietSchedule.GetUserTodaysPlanAsync(userId);
        }

        // GET: api/<TreningPlanController>/GetAllPlans
        [HttpGet("GetAllPlans")]
        public async Task<List<FullModel>> GetAllPlans()
        {
            return await _trainingAndDietSchedule.GetAllPlans();
        }

        // GET: api/<TreningPlanController>/GetAllUserPlans/{userId:int}
        [HttpGet("GetAllUserPlans/{userId:int}")]
        public async Task<List<FullModel>> GetAllUserPlans(int userId)
        {
            return await _trainingAndDietSchedule.GetAllUserPlansAsync(userId);
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
