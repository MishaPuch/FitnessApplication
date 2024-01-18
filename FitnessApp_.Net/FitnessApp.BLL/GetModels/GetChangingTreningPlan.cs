using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.GetModels
{
    public class GetChangingTreningPlan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ActualUserTreningPlanId { get; set; }
        public int DisaredTeningPlan {  get; set; }
        public bool IsApproved { get; set; }
    }
}
