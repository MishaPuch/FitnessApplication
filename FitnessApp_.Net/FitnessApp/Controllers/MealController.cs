using FitnessApp.BLL.Interface;
using FitnessApp.DAL.Models;
using FitnessApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;
        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        // GET: api/<DietsController>
        [HttpGet("getAllMealAsync")]
        public async Task<List<Meal>> GetAllMealAsync()
        {
            return await _mealService.GetAllMealsAsync();
        }

        // GET api/<DietsController>/5
        [HttpGet("getMealByIdAsync/{id:int}")]
        public async Task<Meal> GetMealByIdAsync(int id)
        {
            return await _mealService.GetMealByIdAsync(id);
        }

        // POST api/<DietsController>
        [HttpPost("createMealAsync")]
        public async Task<ActionResult> CreateMealAsync([FromBody] Meal meal)
        {
            await _mealService.CreateMealAsync(meal);
            return Ok(meal);
        }

        // PUT api/<DietsController>/5
        [HttpPut("updateMealAsync")]
        public async Task<Meal> UpdateMealAsync ([FromBody] Meal meal)
        {
            return await _mealService.UpdateMealAsync(meal);
        }

        // DELETE api/<DietsController>/5
        [HttpDelete("deleteMeal/{id:int}")]
        public async Task<ActionResult> DeleteMeal(int id)
        {
            await _mealService.DeleteMealAsync(id);
            return Ok();
        }
    }
}
