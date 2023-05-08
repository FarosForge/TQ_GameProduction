using Building;
using UI.Data;

namespace UI
{
    public class ProductionWindowData : ISendData
    {
        public IBuildingView building;

        public ProductionWindowData(IBuildingView building)
        {
            this.building = building;
        }
    }
}