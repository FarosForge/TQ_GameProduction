using Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ItemSlot : MonoBehaviour
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
}