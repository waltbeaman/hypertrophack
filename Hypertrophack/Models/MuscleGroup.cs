namespace Hypertrophack.Models
{
    public class MuscleGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int MV { get; set; }
        public int MEV { get; set; }
        public int MAV { get; set; }
        public int MRV { get; set; }
    }
}
