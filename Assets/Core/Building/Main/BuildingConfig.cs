using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "GAME/Buildings/New Building")]
public class BuildingConfig : ScriptableObject
{
    public int ID;
    public BuildingType type;
    public float ProductionTime;
}
