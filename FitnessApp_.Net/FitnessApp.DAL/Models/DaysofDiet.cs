using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class DaysofDiet
    {
        
        public int Id { get; set; }
        public int DayId { get; set; }
        public int TreningId { get; set; }        
        public string Times { get; set; }
        public int UserId { get; set; }
        public int DietId { get; set; } 
    }
}
