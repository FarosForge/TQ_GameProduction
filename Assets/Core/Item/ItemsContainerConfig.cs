using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsContainerConfig", menuName = "GAME/Items/ItemsContainerConfig")]
public class ItemsContainerConfig : ScriptableObject
{
    [SerializeField] private List<ItemConfig> itemsList;
    [SerializeField] private List<ItemConfig> resourcesList;

    public List<ItemConfig> ItemsList { get => itemsList; }
    public List<ItemConfig> ResourcesList { get => resourcesList; }
}
