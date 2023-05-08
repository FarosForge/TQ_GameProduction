using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingModel : IBuilding
{
    public IWork work { get; private set; }

    public BuildingType type { get; private set; }

    public BuildingModel(BuildingConfig config)
    {
        this.type = config.type;

        switch (type)
        {
            case BuildingType.Resource:
                work = new WorkMining(config.ProductionTime);
                break;
            case BuildingType.Produtction:
                work = new WorkProduction(config.ProductionTime);
                break;
            case BuildingType.Shop:
                break;
        }
    }

}
