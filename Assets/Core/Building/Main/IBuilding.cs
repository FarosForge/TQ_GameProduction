using Work;

namespace Building
{
    public interface IBuilding
    {
        IWork work { get; }
        BuildingType type { get; }
    }
}