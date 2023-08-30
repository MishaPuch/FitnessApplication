using FitnessApp.DAL.Models;

namespace FitnessApp.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDescription { get; set; }
        public string ExerciseVideo { get; set; }

        public int MuscleGroupId { get; set; } 
        public virtual TypeOfMuscleGroup MuscleGroup { get; set; } 
    }

}
