using Item;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SelectorSlot : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Button button;

        private I_Item item;

        public void SetData(I_Item item, Action<I_Item> action, Action actionSelect, SelectorDataType type = SelectorDataType.Resource)
        {
            this.item = item;
            icon.sprite = item.Icon;

            if (type == SelectorDataType.Items)
            {
                if (item.Count <= 0)
                {
                    button.interactable = false;
                }
            }

            button.onClick.AddListener(() =>
            {
                action?.Invoke(this.item);
                actionSelect?.Invoke();

            });
        }
    }
}