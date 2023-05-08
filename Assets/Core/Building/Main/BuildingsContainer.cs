using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsContainer
{
    private Dictionary<int, IBuilding> resourceBuildingsList = new();
    private Dictionary<int, IBuilding> productionBuildingsList = new();
    private BuildingsContainerConfig config;
    private BuildingsViewContainer buildingsView;
    private SessionManager session;

    public Dictionary<int, IBuilding> ResourceBuildingsList { get => resourceBuildingsList; }
    public Dictionary<int, IBuilding> ProductionBuildingsList { get => productionBuildingsList; }

    public BuildingsContainer(SessionManager session)
    {
        this.config = session.BuildingsConfig;
        this.buildingsView = session.BuildingsView;
        this.session = session;
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < config.ResourceBuildings.Count; i++)
        {
            var building = config.ResourceBuildings[i];
            CreateBuilding(building, i);
        }

        for (int i = 0; i < config.ProductionBuildings.Count; i++)
        {
            var building = config.ProductionBuildings[i];
            CreateBuilding(building, i);
        }
    }
    

    private void CreateBuilding(BuildingConfig building, int ID)
    {

        IBuilding build = new BuildingModel(building);

        switch (building.type)
        {
            case BuildingType.Resource:
                if (resourceBuildingsList.ContainsKey(building.ID)) return;
                
                buildingsView.ResorceBuildings[ID].SetModel(build);
                resourceBuildingsList.Add(building.ID, build);
                break;
            case BuildingType.Produtction:
                if (productionBuildingsList.ContainsKey(building.ID)) return;

                buildingsView.ProductionBuildings[ID].SetModel(build);
                productionBuildingsList.Add(building.ID, build);
                break;
            case BuildingType.Shop:
                break;
        }

    }
}
