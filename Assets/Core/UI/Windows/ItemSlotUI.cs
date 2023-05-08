using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI textCount;

    public I_Item Item { get; private set; }

    public void SetData(I_Item item)
    {
        Item = item;
        icon.sprite = item.Icon;
        textCount.text = item.Count.ToString();
    }

    public void UpdateSlot()
    {
        SetData(Item);
    }
}
