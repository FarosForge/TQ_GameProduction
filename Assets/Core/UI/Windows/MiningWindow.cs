using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UI.Data;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MiningWindow : BuildingWindow
{
    [SerializeField] private Image slider;
    [SerializeField] private Button startButton;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private SlotSelector slot;

    private IBuildingView building;
    private IResource[] resource;

    public override void SetData(ISendData data)
    {
        resource = new IResource[resourceSlotsCount];

        switch (data)
        {
            case MiningWindowData listener:

                building = listener.building;

                resource[0] = building.currentModel.work.Resources[0];

                if (resource[0] != null)
                {
                    slot.Select(resource[0]);
                }
                else
                {
                    slot.ClearSlot();
                }

                slot.OnSelected += UpdateWindow;

                UpdateWindow();
                Activate();
                break;
        }
    }

    private void OnDestroy()
    {
        slot.OnSelected -= UpdateWindow;
    }

    private void StartMining()
    {
        Debug.Log("Start Mining");
        building.currentModel.work.StartWork(new WorkMinigData(resource[0]));
        UpdateWindow();
    }

    private void StopMining()
    {
        building.currentModel.work.StopWork();
        UpdateWindow();
    }

    private void UpdateWindow()
    {
        if (!building.currentModel.work.InWorking)
        {
            if (slot.IsFull)
            {
                startButton.onClick.RemoveAllListeners();
                startButton.onClick.AddListener(() => StartMining());
            }
            startButton.image.color = Color.white;
            startButton.interactable = slot.IsFull;
            slot.SetInteractable(true);
            buttonText.text = "START";
        }
        else
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(() => StopMining());
            startButton.image.color = Color.red;
            startButton.interactable = true;
            slot.SetInteractable(false);
            buttonText.text = "STOP";
        }
    }

    public override void SetResource(I_Item resource, int id)
    {
        this.resource[id] = (IResource)resource;
    }

    public override void Deactivate()
    {
        UIEventsTranslator.Call(UIEventsTranslator.GetKey(nameof(ItemsSelector) + "Deact"));
        base.Deactivate();
    }
}
