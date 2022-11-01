using Hypertrophack.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Hypertrophack.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public DbSet<MuscleGroup> MuscleGroups { get; set; } = null!;
        public DbSet<CompletedExercise> CompletedExercises { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeeklyProgress>().Metadata.SetIsTableExcludedFromMigrations(true);
        }
    }
}