using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuldingsContainerConfig", menuName = "GAME/Buildings/BuldingsContainerConfig")]
public class BuildingsContainerConfig : ScriptableObject
{
    [SerializeField] private List<BuildingConfig> resourceBuildings = new();
    [SerializeField] private List<BuildingConfig> productionBuildings = new();

    public List<BuildingConfig> ResourceBuildings { get => resourceBuildings; }
    public List<BuildingConfig> ProductionBuildings { get => productionBuildings; }
}
