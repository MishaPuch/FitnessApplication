using FitnessApp.DAL.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitnessApp.Models
{
    public class User
    {

        [JsonProperty("Id")]
        public int Id { get; set; }
        [StringLength(100)]
        [JsonProperty("UserName")]
        public string UserName { get; set; }
        [RegularExpression(@"^[A-Za-z0-9+_.-]+@[A-Za-z0-9.-]+$")]
        [Required]
        [JsonProperty("UserEmail")]
        public string UserEmail { get; set; }
        public bool IsEmailConfirmed { get; set; }
        [StringLength(100)]
        [Required]
        public string Password { get; set; }
        public string Sex { get; set; }
        [Range(0, 110)]
        public int Age { get; set; }
        public int RestTime { get; set; }
        public int CalorificValue { get; set; } 
        public DateTime DateOFLastPayment { get; set; }
        public int TreningPlanId { get; set; }
        public TreningPlan TreningPlan { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Avatar { get; set; }

    }
}
