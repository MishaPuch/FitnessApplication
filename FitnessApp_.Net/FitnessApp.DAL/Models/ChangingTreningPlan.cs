using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Models
{
    public class ChangingTreningPlan
    {
        public int Id { get; set; }
        public int UserId {  get; set; }
        public User User { get; set; }
        public int ActualUserTreningPlan { get; set; }
        public int DisiredTreningPlan { get; set; }
        public bool? IsApproved { get; set; } = null;
    }
}
