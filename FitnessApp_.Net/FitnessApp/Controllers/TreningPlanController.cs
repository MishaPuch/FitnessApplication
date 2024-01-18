using FitnessApp.BLL.DI_Service;
using FitnessApp.BLL.GetModels;
using FitnessApp.BLL.Interface;
using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using FitnessApp.DAL.ViewModel;
using FitnessApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;
using NLog.LayoutRenderers;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreningPlanController : ControllerBase
    {
        private readonly ITrainingAndDietScheduleService _trainingAndDietSchedule;
        private readonly IUserService _userService;
        private readonly ITreningService _treningService;
        private readonly IChangingTreningPlanService _changingTreningPlanService;

        public TreningPlanController(ITrainingAndDietScheduleService trainingAndDietSchedule, IUserService userService, ITreningService treningService, IChangingTreningPlanService changingTreningPlanService)
        {
            _trainingAndDietSchedule = trainingAndDietSchedule;
            _userService = userService;
            _treningService = treningService;
            _changingTreningPlanService = changingTreningPlanService;
        }

        // GET: api/<TreningPlanController>/GetPlan/{userId:int}
        [HttpGet("GetDalyPlan/{userId:int}/{day:DateTime}")]
        public async Task<List<FullModel>> GetDalyPlan(int userId, DateTime day)
        {
            DateTime date = day.AddDays(1);
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
        // POST : api/<TreningPlanController>/ChangeTreningPlanAsync
        [HttpPost("ChangeTreningPlanAsync/{changingTreningPlanId:int}/{decision:bool}")]
        public async Task<IActionResult> ChangeTreningPlanAsync(int changingTreningPlanId , bool decision)
        {
            try
            {
                ChangingTreningPlan changingTreningPlan = await _changingTreningPlanService.GetChangingTreningPlanByIdAsync(changingTreningPlanId);

                if (changingTreningPlan != null)
                {
                    int countOfDisaredTreningPlan = 0;

                    changingTreningPlan.IsApproved = decision;
                    ChangingTreningPlan newChangingTreningPlan = await _changingTreningPlanService.UpdateChangingTreningPlanAsync(changingTreningPlan);

                    User user = await _userService.GetUserByIdAsync(newChangingTreningPlan.UserId);
                    if (user != null)
                    {

                        if (newChangingTreningPlan.IsApproved == true)
                        {
                            List<TreningAndDietSchedule> treningAndDietSchedules = await _trainingAndDietSchedule
                                .GetTreningAndDietForRestMonthByUserId(newChangingTreningPlan.UserId);
                            foreach (TreningAndDietSchedule treningAndDietSchedule in treningAndDietSchedules)
                            {
                                List<Trening> trenings = await _treningService.GetTreningsByTreningScheduleIdAsync(treningAndDietSchedule.Id);

                                foreach (Trening trening in trenings)
                                {
                                    if (trening != null)
                                    {
                                        if (trening.TreningPlanId == newChangingTreningPlan.DisiredTreningPlan)
                                        {
                                            countOfDisaredTreningPlan++;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (countOfDisaredTreningPlan == 0)
                            {
                                List<Trening> trenings = await _treningService.MakeTreningForAMonthAsync(treningAndDietSchedules, newChangingTreningPlan.DisiredTreningPlan);
                                user.TreningPlanId = newChangingTreningPlan.DisiredTreningPlan;
                                await _userService.CangeUserDataAsync(user);
                            }
                            else
                            {
                                user.TreningPlanId = newChangingTreningPlan.DisiredTreningPlan;
                                await _userService.CangeUserDataAsync(user);
                            }
                        }
                        
                    }
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        // GET : api/<TreningPlanController>/GetAllChangingTreningPlanRequestAsync
        [HttpGet("GetAllChangingTreningPlanRequestAsync")]
        public async Task<List<ChangingTreningPlan>> GetAllChangingTreningPlanRequestAsync ()
        {
            return await _changingTreningPlanService.GetAllChangingTreningPlansAsync();
        }

/* // POST : api/<TreningPlanController>/CreateChangingTreningPlanRequest
 [HttpPost("CreateChangingTreningPlanRequest")]
 public async Task<IActionResult> CreateChangingTreningPlanRequestAsync (GetChangingTreningPlan gotChangingTreningPlan)
 {
     ChangingTreningPlan changingTreningPlan = new ChangingTreningPlan()
     {
         UserId = gotChangingTreningPlan.UserId,
         User = await _userService.GetUserByIdAsync(gotChangingTreningPlan.UserId),
         ActualUserTreningPlan = gotChangingTreningPlan.ActualUserTreningPlanId,
         DisiredTreningPlan = gotChangingTreningPlan.DisaredTeningPlan,
         IsApproved = null
     };
     try
     {
         await _changingTreningPlanService.CreateChangingTreningPlanAsync(changingTreningPlan);
     }
     catch (Exception ex)
     {
         return BadRequest(ex.Message);
     }
     return Ok();
 }*/


    }
}
