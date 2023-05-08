using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Building
{
    public class ResorceBuilding : MonoBehaviour, IBuildingView
    {
        public IBuilding currentModel { get; private set; }

        public void OnMouseDown()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
                OnClick();
        }

        public void OnClick()
        {
            UIEventsTranslator.Call(UIEventsTranslator.GetKey(nameof(MiningWindow)), new MiningWindowData(this));
        }

        public void SetModel(IBuilding model)
        {
            currentModel = model;
        }
    }
}