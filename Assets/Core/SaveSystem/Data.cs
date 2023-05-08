using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int Currency;

    public List<ItemData> items = new();
}

[System.Serializable]
public class ItemData
{
    public string ID;
    public int Count;

    public ItemData(string iD, int count)
    {
        ID = iD;
        Count = count;
    }
}
