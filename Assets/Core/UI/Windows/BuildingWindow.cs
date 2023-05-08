using Item;
using UI.Data;
using UnityEngine;

namespace UI
{
    public abstract class BuildingWindow : UIWindow
    {
        [SerializeField] [Range(1, 4)] internal int resourceSlotsCount;

        public virtual void SetData(ISendData data) { }
        public virtual void SetResource(I_Item resource, int id) { }
    }
}