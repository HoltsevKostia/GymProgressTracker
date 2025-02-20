namespace GymProgressTracker.Server.Models.DTO.Workout
{
    public class AddWorkoutDTO
    {
        public DateTime Date { get; set; }
        public required int UserId { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}
