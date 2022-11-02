namespace Hypertrophack.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public List<CompletedExercise> CompletedExercises { get; set; } = null!;
    }
}
