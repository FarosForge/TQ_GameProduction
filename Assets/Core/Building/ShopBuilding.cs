using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopBuilding : MonoBehaviour, IBuildingView
{
    public IBuilding currentModel { get; private set; }

    public void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            OnClick();
    }

    public void OnClick()
    {
        UIEventsTranslator.Call(UIEventsTranslator.GetKey(nameof(ShopWindow)));
    }

    public void SetModel(IBuilding model)
    {
        currentModel = model;
    }
}
