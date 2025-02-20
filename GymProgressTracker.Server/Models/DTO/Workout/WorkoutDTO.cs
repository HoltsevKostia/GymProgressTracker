namespace GymProgressTracker.Server.Models.DTO.Workout
{
    public class WorkoutDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public required int UserId { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}
