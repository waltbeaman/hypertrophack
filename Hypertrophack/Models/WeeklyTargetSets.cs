namespace Hypertrophack.Models
{
    public class WeeklyTargetSets : IWeeklyTargetSets
    {
        public int ChestMaint { get; } = 5;
        public int ChestMin { get; } = 6;
        public int ChestMax { get; } = 20;

        public int BackMaint { get; } = 6;
        public int BackMin { get; } = 10;
        public int BackMax { get; } = 20;

        public int LegMaint { get; } = 6;
        public int LegMin { get; } = 8;
        public int LegMax { get; } = 25;

        public int ArmMaint { get; } = 4;
        public int ArmMin { get; } = 8;
        public int ArmMax { get; } = 22;

        public int ShoulderMaint { get; } = 0;
        public int ShoulderMin { get; } = 6;
        public int ShoulderMax { get; } = 16;
    }
}