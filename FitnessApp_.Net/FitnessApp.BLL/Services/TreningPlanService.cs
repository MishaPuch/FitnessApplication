using FitnessApp.BLL.Interface;
using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Services
{
    public class TreningPlanService : ITreningPlanService
    {
        private readonly ITreningPlanRepository _treningPlanRepository;
        public TreningPlanService(ITreningPlanRepository treningPlanRepository)
        {
            _treningPlanRepository = treningPlanRepository;
        }

        public async Task<TreningPlan> GetTreningPlanByIdAsync(int id)
        {
            return await _treningPlanRepository.GetTreningPlanByIdAsync(id);
        }
    }
}
