using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FitnessApp.DAL.Models
{
    public class Trening
    {
        public int Id { get; set; }
        public int DayId { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
        public int MuscleGroupId { get; set; }
        public virtual TypeOfMuscleGroup MuscleGroup { get; set; }
        [JsonIgnore]
        public virtual TrainingAndDietSchedule TrainingAndDietSchedules { get; set; }
        public string Times { get; set; }



    }
}
