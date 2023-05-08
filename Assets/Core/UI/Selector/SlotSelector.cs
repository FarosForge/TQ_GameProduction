using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotSelector : MonoBehaviour, IPointerDownHandler
{
    public Action OnSelected;

    [SerializeField] private int ID;
    [SerializeField] private Image icon;
    [SerializeField] private BuildingWindow window;
    [SerializeField] private SelectorDataType type;

    public bool IsFull { get; private set; }
    public bool Interactable { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!Interactable) return;

        UIEventsTranslator.Call(UIEventsTranslator.GetKey(nameof(ItemsSelector)), new ItemsSelectorData(this, type));
    }

    public void Select(I_Item resource)
    {
        window.SetResource(resource, ID);
        icon.sprite = resource.Icon;
        icon.enabled = true;
        IsFull = true;
        OnSelected?.Invoke();
    }

    public void ClearSlot()
    {
        icon.enabled = false;
        IsFull = false;
    }

    public void SetInteractable(bool val)
    {
        Interactable = val;
    }
}
