using FitnessApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.GetModels
{
    public class GetExercise
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDescription { get; set; }
        public string ExerciseVideo { get; set; }
        public int MuscleGroupId { get; set; }
        public int TypeOfTreningId { get; set; }
        public int Statistic {  get; set; }
    }
}
