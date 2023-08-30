using FitnessApp.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Models
{
    public class Diet
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
        public int DayId { get; set; }

    }
}

