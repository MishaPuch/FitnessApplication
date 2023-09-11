using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.DAL.Models
{
    public class CalorificCoefficientValue
    {
        public int Id { get; set; }
        [Required]
        public double CalorificValue { get; set; }
        [Required]
        public double CalorificCoefficient { get; set; }
        public int TypeOfMealId { get; set; } 

        [ForeignKey("TypeOfMealId")]
        public virtual TypeOfMeal TypeOfMeal { get; set; }
    }
}
