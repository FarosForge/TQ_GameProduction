using System.Collections;
using System.Collections.Generic;
using UI.Data;
using UnityEngine;

public class MiningWindowData : ISendData
{
    public IBuildingView building;

    public MiningWindowData(IBuildingView building)
    {
        this.building = building;
    }
}
