namespace GymProgressTracker.Server.Models.DTO.WorkoutEntry
{
    public class AddWorkoutEntryDTO
    {
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
        public double Weight { get; set; }
        public int Reps { get; set; }
    }
}
