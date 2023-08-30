using FitnessApp.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class DaysOfDietAndExercise
    {
        public int Id { get; set; }

        [Required]
        public int DayId { get; set; }

        [Required]
        public int TreningId { get; set; }
        public Trening Trening { get; set; }

        public string Times { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int DietId { get; set; }
        public Diet Diet { get; set; }

        public int Month { get; set; }
    }
}
