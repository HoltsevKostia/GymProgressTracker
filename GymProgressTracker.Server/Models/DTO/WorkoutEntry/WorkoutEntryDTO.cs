namespace GymProgressTracker.Server.Models.DTO.WorkoutEntry
{
    public class WorkoutEntryDTO
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
        public double Weight { get; set; }
        public int Reps { get; set; }
    }
}
