using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Global.Wallet;
using Game;
using Item;

namespace UI
{
    public class ShopWindow : BuildingWindow
    {
        [SerializeField] private SlotChanger slot;
        [SerializeField] private Button sellButton;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private GameObject countObject;

        private SessionManager session;
        private I_Item currentItem;

        [Inject]
        public void Construct(SessionManager session)
        {
            this.session = session;
        }

        public void Start()
        {
            sellButton.onClick.AddListener(() => Sell());
            slot.OnSelected += UpdateWindow;
            slot.SetInteractable(true);
            UpdateWindow();
        }

        private void OnDestroy()
        {
            slot.OnSelected -= UpdateWindow;
        }

        private void UpdateWindow()
        {
            sellButton.interactable = currentItem != null;
            priceText.text = currentItem == null ? "0" : currentItem.Price.ToString();
            countObject.SetActive(currentItem != null);
            if (currentItem != null)
                countText.text = currentItem.Count.ToString();
        }

        public void Sell()
        {
            if (currentItem == null) return;

            session.Wallet.GetCurrency(CurrencyType.Gold).OnAddedCurrencyValue(currentItem.Price);
            UIEventsTranslator.Call(UIEventsTranslator.GetKey(nameof(WalletUI)),
                new WalletUIData(session.Wallet.GetCurrency(CurrencyType.Gold).GetValue()));
            currentItem.Remove(1);
            slot.ClearSlot();
            currentItem = null;
            UpdateWindow();
        }

        public override void SetResource(I_Item resource, int id)
        {
            currentItem = resource;
        }

        public override void Deactivate()
        {
            UIEventsTranslator.Call(UIEventsTranslator.GetKey(nameof(ItemsSelector) + "Deact"));
            slot.ClearSlot();
            base.Deactivate();
        }
    }
}