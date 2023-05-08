using Building;
using Config;
using Game;
using Item;
using TMPro;
using UI.Data;
using UnityEngine;
using UnityEngine.UI;
using Work;
using Zenject;

namespace UI
{
    public class ProductionWindow : BuildingWindow
    {
        [SerializeField] private Image resultIcon;
        [SerializeField] private Button startButton;
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private SlotChanger[] slots;

        private IBuildingView building;
        private IResource[] resource;
        private SessionManager session;
        private int recipeID = -1;

        [Inject]
        public void Construct(SessionManager session)
        {
            this.session = session;
        }

        public override void SetData(ISendData data)
        {
            resource = new IResource[resourceSlotsCount];

            switch (data)
            {
                case ProductionWindowData listener:

                    building = listener.building;

                    for (int i = 0; i < building.currentModel.work.Resources.Length; i++)
                    {
                        resource[i] = building.currentModel.work.Resources[i];

                        var slot = slots[i];

                        if (resource[i] != null)
                        {
                            slot.Select(resource[i]);
                        }
                        else
                        {
                            slot.ClearSlot();
                        }

                        slot.OnSelected += UpdateWindow;
                    }

                    UpdateWindow();
                    Activate();
                    break;
            }
        }

        private void OnDestroy()
        {
            foreach (var slot in slots)
                slot.OnSelected -= UpdateWindow;
        }

        private void StartProduction()
        {
            Debug.Log("Start Mining");
            building.currentModel.work.OnStopWorking += UpdateWindow;
            building.currentModel.work.StartWork(new WorkProductionData(resource, recipeID, session));
            UpdateWindow();
        }

        private void StopProduction()
        {
            building.currentModel.work.StopWork();
            building.currentModel.work.OnStopWorking -= UpdateWindow;
        }

        private void UpdateWindow()
        {
            if (!building.currentModel.work.InWorking)
            {
                foreach (var slot in slots)
                {
                    if (slot.IsFull)
                    {
                        startButton.onClick.RemoveAllListeners();
                        startButton.onClick.AddListener(() => StartProduction());
                    }
                    slot.SetInteractable(true);
                }
                startButton.image.color = Color.white;
                buttonText.text = "START";

                if (!CheckValidateResources())
                {
                    SetButtonProperty(false, -1);
                    return;
                }

                for (int i = 0; i < session.RecipesList.Recipes.Length; i++)
                {
                    RecipeConfig recipe = session.RecipesList.Recipes[i];
                    ItemConfig item = recipe.GetResult(new string[] { resource[0].ID, resource[1].ID });
                    if (item != null)
                    {
                        resultIcon.sprite = item.icon;
                        SetButtonProperty(true, i);
                        return;
                    }
                    else
                    {
                        SetButtonProperty(false, -1);
                    }
                }
            }
            else
            {
                startButton.onClick.RemoveAllListeners();
                startButton.onClick.AddListener(() => StopProduction());
                startButton.image.color = Color.red;
                startButton.interactable = true;
                foreach (var slot in slots)
                    slot.SetInteractable(false);
                buttonText.text = "STOP";
            }
        }

        private void SetButtonProperty(bool interactable, int id)
        {
            startButton.interactable = interactable;
            resultIcon.enabled = interactable;
            recipeID = id;
        }

        private bool CheckValidateResources()
        {
            if (resource[0] == null || resource[1] == null)
            {
                return false;
            }

            foreach (var res in resource)
            {
                if (res.Count <= 0)
                    return false;
            }

            return true;
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

        private bool CheckFullSlots()
        {
            foreach (var slot in slots)
            {
                if (!slot.IsFull) return false;
            }

            return true;
        }
    }
}