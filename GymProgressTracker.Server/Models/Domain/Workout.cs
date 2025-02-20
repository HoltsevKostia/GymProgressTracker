using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymProgressTracker.Server.Models.Domain
{
    [Table("Workout")]
    public class Workout
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public required int UserId { get; set; }
        public TimeSpan? Duration { get; set; }
        public User User { get; set; }

        public ICollection<WorkoutEntry> WorkoutEntries { get; set; }
    }
}

