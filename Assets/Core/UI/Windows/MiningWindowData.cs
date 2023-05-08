using Building;
using UI.Data;

namespace UI
{
    public class MiningWindowData : ISendData
    {
        public IBuildingView building;

        public MiningWindowData(IBuildingView building)
        {
            this.building = building;
        }
    }
}