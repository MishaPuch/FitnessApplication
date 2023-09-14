using FitnessApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FitnessApp.Models
{
    public class Diet
    {
       
        public int Id { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
        public int TrainingAndDietScheduleId { get; set; }
        [JsonIgnore]
        public virtual TreningAndDietSchedule TrainingAndDietSchedule { get; set; }

    }
}

