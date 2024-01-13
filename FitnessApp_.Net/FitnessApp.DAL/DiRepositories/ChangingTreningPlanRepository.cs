using FitnessApp.DAL.interfaceRepositories;
using FitnessApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.DiRepositories
{
    public class ChangingTreningPlanRepository:IChangingTreningPlanRepository
    {
        private readonly FitnessAppContext _context;
        public ChangingTreningPlanRepository(FitnessAppContext context)
        {
            _context = context;
        }
        public async Task<ChangingTreningPlan> GetChangingTreningPlanByUserIdAsync(int userId)
        {
            ChangingTreningPlan changingTreningPlan =await _context.ChangingTreningPlans.LastOrDefaultAsync(x=>x.UserId==userId);

            return changingTreningPlan;
        }
        public async Task<ChangingTreningPlan> GetChangingTreningPlanByIdAsync(int changingTreningPlanId)
        {
            ChangingTreningPlan changingTreningPlan = await _context.ChangingTreningPlans.LastOrDefaultAsync(x => x.Id == changingTreningPlanId);

            return changingTreningPlan;
        }
        public async Task<List<ChangingTreningPlan>> GetAllChangingTreningPlansAsync()
        {
            return _context.ChangingTreningPlans.ToList();
        }
        public async Task<ChangingTreningPlan> CreateChangingTreningPlanAsync(ChangingTreningPlan changingTreningPlan)
        {
            await _context.ChangingTreningPlans.AddAsync(changingTreningPlan);
            await _context.SaveChangesAsync();

            return changingTreningPlan;
        }
        public async Task<ChangingTreningPlan> UpdateChangingTreningPlanAsync(ChangingTreningPlan changingTreningPlan)
        {
            _context.ChangingTreningPlans.Update(changingTreningPlan);
            await _context.SaveChangesAsync();

            return changingTreningPlan;
        }
        public async Task<ChangingTreningPlan> UpdateChangingTreningPlanAsync(int changingTreningPlanId , bool decision)
        {
            ChangingTreningPlan changingTreningPlan = await GetChangingTreningPlanByIdAsync(changingTreningPlanId);
            changingTreningPlan.IsApproved=decision;
            _context.ChangingTreningPlans.Update(changingTreningPlan);
            await _context.SaveChangesAsync();
            return changingTreningPlan;
        }
    }
}
