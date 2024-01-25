using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.GetModels
{
    public class GetUser
    {
        [StringLength(100)]
        public string UserName { get; set; }
        [RegularExpression(@"^[A-Za-z0-9+_.-]+@[A-Za-z0-9.-]+$")]
        [Required]
        public string UserEmail { get; set; }
        [StringLength(100)]
        [Required]
        public string Password { get; set; }
        public bool IsEmailConfirmed { get; set; }

        public string Sex { get; set; }
        [Range(0, 110)]
        public int Age { get; set; }
        public int RestTime { get; set; }
        public int CalorificValue { get; set; }
        public DateTime DateOFLastPayment { get; set; }
        public int TreningPlanId { get; set; }
        public int RoleId { get; set; }
    }
}
