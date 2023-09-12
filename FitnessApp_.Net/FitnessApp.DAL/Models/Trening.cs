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
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
        public int TrainingAndDietSchedulesId { get; set; }
        [JsonIgnore]
        public virtual TreningAndDietSchedule TrainingAndDietSchedules { get; set; }
        public string Times { get; set; }
    }
}
