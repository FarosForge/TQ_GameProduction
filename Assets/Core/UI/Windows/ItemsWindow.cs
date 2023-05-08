using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemsWindow : MonoBehaviour
{
    [SerializeField] private ItemSlotUI slotPrefab;

    private SessionManager session;
    private List<ItemSlotUI> list = new();

    [Inject]
    public void Construct(SessionManager session)
    {
        this.session = session;
    }

    public void Init()
    {
        foreach (var item in session.ItemsContainer.ResourcesList)
        {
            CreateSlot(item.Value);
        }

        foreach (var item in session.ItemsContainer.ItemsList)
        {
            CreateSlot(item.Value);
        }
    }

    private void CreateSlot(I_Item item)
    {
        var slot = Instantiate(slotPrefab);
        slot.transform.SetParent(transform);
        slot.transform.localScale = Vector3.one;
        item.OnUpdateCount += UpdateWindow;
        slot.SetData(item);
        list.Add(slot);
    }

    private void UpdateWindow()
    {
        foreach (var item in list)
        {
            item.UpdateSlot();
        }
    }
}
