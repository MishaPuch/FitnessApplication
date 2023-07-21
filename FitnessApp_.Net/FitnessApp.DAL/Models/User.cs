using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class User
    {
        public int id { get; set; }
        [StringLength(100)]
        public string userName { get; set; }
        [RegularExpression(@"^[A-Za-z0-9+_.-]+@[A-Za-z0-9.-]+$")]
        [Required]
        public string userEmail { get; set; }
        [StringLength(100)]
        [Required]
        public string password { get; set; }
        public string sex { get; set; }
        [Range(0, 110)]
        public int age { get; set; }
        public int restTime { get; set; }
        public int calorificValue { get; set; }
    }
}
