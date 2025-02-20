using GymProgressTracker.Server.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GymProgressTracker.Server.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutEntry> WorkoutEntries { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Workout>()
                .HasOne(w => w.User)
                .WithMany(u => u.Workouts)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Workout>()
                .HasMany(w => w.WorkoutEntries)
                .WithOne(we => we.Workout)
                .HasForeignKey(we => we.WorkoutId);

            modelBuilder.Entity<Exercise>()
                .HasMany(e => e.WorkoutEntries)
                .WithOne(we => we.Exercise)
                .HasForeignKey(we => we.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
