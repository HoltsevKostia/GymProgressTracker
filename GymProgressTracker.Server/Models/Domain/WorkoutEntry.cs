using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymProgressTracker.Server.Models.Domain
{
    [Table("WorkoutEntry")]
    public class WorkoutEntry
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; } 

        public double Weight { get; set; }
        public int Reps { get; set; }
    }
}
