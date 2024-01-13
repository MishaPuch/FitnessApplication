using FitnessApp.BLL.Interface;
using FitnessApp.DAL.DiRepositories;
using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Services
{
    public class ChangingTreningPlanService : IChangingTreningPlanService
    {
        public readonly IChangingTreningPlanRepository _changingTreningPlanRepository;
        public ChangingTreningPlanService(IChangingTreningPlanRepository changingTreningPlanRepository )
        {
            _changingTreningPlanRepository = changingTreningPlanRepository;
        }

        public async Task<ChangingTreningPlan> CreateChangingTreningPlanAsync(ChangingTreningPlan changingTreningPlan)
        {
             return await _changingTreningPlanRepository.CreateChangingTreningPlanAsync(changingTreningPlan);
        }

        public async Task<List<ChangingTreningPlan>> GetAllChangingTreningPlansAsync()
        {
            return await _changingTreningPlanRepository.GetAllChangingTreningPlansAsync();
        }

        public async Task<ChangingTreningPlan> GetChangingTreningPlanByIdAsync(int changingTreningPlanId)
        {
            return await _changingTreningPlanRepository.GetChangingTreningPlanByIdAsync(changingTreningPlanId);
        }

        public async Task<ChangingTreningPlan> GetChangingTreningPlanByUserIdAsync(int userId)
        {
            return await _changingTreningPlanRepository.GetChangingTreningPlanByIdAsync(userId);
        }

        public async Task<ChangingTreningPlan> UpdateChangingTreningPlanAsync(ChangingTreningPlan changingTreningPlan)
        {
            return await _changingTreningPlanRepository.UpdateChangingTreningPlanAsync(changingTreningPlan);
        }

        public async Task<ChangingTreningPlan> UpdateChangingTreningPlanAsync(int changingTreningPlanId, bool decision)
        {
            return await _changingTreningPlanRepository.UpdateChangingTreningPlanAsync(changingTreningPlanId, decision);
        }
    }
}
