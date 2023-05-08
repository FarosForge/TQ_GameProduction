using System.Collections;
using System.Collections.Generic;
using UI.Data;
using UnityEngine;

public class ItemsSelectorData : ISendData
{
    public SlotSelector selector;
    public SelectorDataType type;

    public ItemsSelectorData(SlotSelector selector, SelectorDataType type)
    {
        this.selector = selector;
        this.type = type;
    }
}

public enum SelectorDataType
{
    Resource,
    Items,
    All
}
