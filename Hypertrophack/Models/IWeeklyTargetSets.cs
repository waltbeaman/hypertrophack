namespace Hypertrophack.Models
{
    public interface IWeeklyTargetSets
    {
        int ArmMaint { get; }
        int ArmMax { get; }
        int ArmMin { get; }
        int BackMaint { get; }
        int BackMax { get; }
        int BackMin { get; }
        int ChestMaint { get; }
        int ChestMax { get; }
        int ChestMin { get; }
        int LegMaint { get; }
        int LegMax { get; }
        int LegMin { get; }
        int ShoulderMaint { get; }
        int ShoulderMax { get; }
        int ShoulderMin { get; }
    }
}