using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class Calendar
    {
        
        public int id { get; set; }
        public DateTime day { get; set; }
        public int exerciseId { get; set; }        
        public int times { get; set; }
        public int dietId { get; set; } 
    }
}
