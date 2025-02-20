using System.ComponentModel.DataAnnotations.Schema;

namespace GymProgressTracker.Server.Models.Domain
{
    [Table("Exercise")]
    public class Exercise
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<WorkoutEntry> WorkoutEntries { get; set; } = new List<WorkoutEntry>();
    }
}
