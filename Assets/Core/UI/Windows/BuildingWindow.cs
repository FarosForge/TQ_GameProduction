using System.Collections;
using System.Collections.Generic;
using UI.Data;
using UnityEngine;

public abstract class BuildingWindow : UIWindow
{
    [SerializeField][Range(1,4)] internal int resourceSlotsCount;

    public virtual void SetData(ISendData data) { }
    public virtual void SetResource(I_Item resource, int id) { }
}
