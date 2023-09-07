using FitnessApp.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FitnessApp.Models
{
    public class TrainingAndDietSchedule
    {
        public int Id { get; set; }

        [Required]
        public int DayId { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        [JsonIgnore]    
        public ICollection<Diet> Diets { get; set; }
        [Required]
        [JsonIgnore]
        public ICollection<Trening> Trainings { get; set; } 
        public int Month { get; set; }

    }
}
