using FitnessApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.interfaceRepositories
{
    public interface IChangingTreningPlanRepository
    {
        public Task<ChangingTreningPlan> GetChangingTreningPlanByUserIdAsync(int userId);
        public Task<ChangingTreningPlan> GetChangingTreningPlanByIdAsync(int changingTreningPlanId);
        public Task<List<ChangingTreningPlan>> GetAllChangingTreningPlansAsync();
        public Task<ChangingTreningPlan> CreateChangingTreningPlanAsync(ChangingTreningPlan changingTreningPlan);
        public Task<ChangingTreningPlan> UpdateChangingTreningPlanAsync(ChangingTreningPlan changingTreningPlan);
        public Task<ChangingTreningPlan> UpdateChangingTreningPlanAsync(int changingTreningPlanId, bool decision);
       
    }
}
