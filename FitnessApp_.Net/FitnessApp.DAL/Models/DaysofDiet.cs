using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class DaysofDiet
    {
        
        public int Id { get; set; }
        public int Day { get; set; }
        public int ExerciseId { get; set; }        
        public string Times { get; set; }
        public int DietId { get; set; } 
    }
}
