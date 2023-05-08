using System;
using UnityEngine;

namespace Item
{
    public interface I_Item
    {
        Action OnUpdateCount { get; set; }
        int Count { get; }
        int Price { get; }
        string ID { get; }
        Sprite Icon { get; }

        void Add(int val);
        void Remove(int val);
    }
}