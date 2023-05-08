using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : IResource
{
    public int Count { get; private set; }
    public int Price { get; private set; }
    public string ID { get; private set; }
    public Sprite Icon { get; private set; }
    public Action OnUpdateCount { get; set; }

    private SaveSystem saveSystem;

    public Resource(int count, ItemConfig config, SaveSystem saveSystem)
    {
        Count = count;
        Price = config.price;
        ID = config.ID;
        Icon = config.icon;
        this.saveSystem = saveSystem;
    }

    public void Add(int val)
    {
        Count++;

        OnUpdateCount?.Invoke();
        saveSystem.Save();
    }

    public void Remove(int val)
    {
        Count--;

        if(Count <= 0)
        {
            Count = 0;
        }

        OnUpdateCount?.Invoke();
        saveSystem.Save();
    }
}
