using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Building
{
    public class ProductionBuilding : MonoBehaviour, IBuildingView
    {
        public IBuilding currentModel { get; private set; }

        public void OnMouseDown()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
                OnClick();
        }

        public void OnClick()
        {
            UIEventsTranslator.Call(UIEventsTranslator.GetKey(nameof(ProductionWindow)), new ProductionWindowData(this));
        }

        public void SetModel(IBuilding model)
        {
            currentModel = model;
        }
    }
}