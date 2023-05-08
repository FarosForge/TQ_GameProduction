using System.Collections;
using System.Collections.Generic;
using UI.Data;
using UnityEngine;

public class ProductionWindowData : ISendData
{
    public IBuildingView building;

    public ProductionWindowData(IBuildingView building)
    {
        this.building = building;
    }
}
