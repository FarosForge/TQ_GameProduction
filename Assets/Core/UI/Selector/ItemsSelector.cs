using Game;
using Item;
using System.Collections.Generic;
using UI.Data;
using UnityEngine;
using Zenject;

namespace UI
{
    public class ItemsSelector : UIWindow
    {
        [SerializeField] private SelectorSlot slotPrefab;
        [SerializeField] private Transform content;

        private SessionManager session;
        private SlotChanger selector;
        private List<SelectorSlot> list = new();

        [Inject]
        public void Construct(SessionManager session)
        {
            this.session = session;
        }

        public void SetData(ISendData data)
        {
            ClearSlots();

            switch (data)
            {
                case ItemsSelectorData listener:
                    selector = listener.selector;
                    switch (listener.type)
                    {
                        case SelectorDataType.Resource:
                            foreach (var item in session.ItemsContainer.ResourcesList)
                            {
                                CreateResourceSlot(item.Value);
                            }
                            break;
                        case SelectorDataType.Items:
                            foreach (var item in session.ItemsContainer.ItemsList)
                            {
                                CreateResourceSlot(item.Value, listener.type);
                            }
                            break;
                        case SelectorDataType.All:
                            break;
                    }

                    Activate();
                    break;
            }
        }

        private void CreateResourceSlot(I_Item item, SelectorDataType type = SelectorDataType.Resource)
        {
            var slot = Instantiate(slotPrefab);
            slot.transform.SetParent(content);
            slot.transform.localScale = Vector3.one;

            slot.SetData(item, selector.Select, Deactivate, type);
            list.Add(slot);
        }

        private void ClearSlots()
        {
            if (list.Count <= 0) return;

            foreach (var item in list)
            {
                Destroy(item.gameObject);
            }

            list.Clear();
        }
    }
}