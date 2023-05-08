using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "GAME/Items/New Item")]
public class ItemConfig : ScriptableObject
{
    public string ID;
    public string saveID;
    public Sprite icon;
    public int price;
}
