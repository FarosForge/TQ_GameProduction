using UnityEngine;

namespace UI
{
    public class WindowsManager : MonoBehaviour
    {
        [SerializeField] private MiningWindow miningWindow;
        [SerializeField] private ItemsSelector itemsSelector;
        [SerializeField] private ProductionWindow productionWindow;
        [SerializeField] private ShopWindow shopWindow;
        [SerializeField] private WalletUI wallet;
        [SerializeField] private ItemsWindow itemsWindow;
        [SerializeField] private GameOverWindow gameOver;

        private void Awake()
        {
            Init();
            CloseAll();
        }

        public void Init()
        {
            UIEventsTranslator.AddListener(UIEventsTranslator.GetKey(nameof(MiningWindow)), miningWindow.SetData);
            UIEventsTranslator.AddListener(UIEventsTranslator.GetKey(nameof(ProductionWindow)), productionWindow.SetData);
            UIEventsTranslator.AddListener(UIEventsTranslator.GetKey(nameof(ItemsSelector)), itemsSelector.SetData);
            UIEventsTranslator.AddListener(UIEventsTranslator.GetKey(nameof(ItemsSelector) + "Deact"), itemsSelector.Deactivate);
            UIEventsTranslator.AddListener(UIEventsTranslator.GetKey(nameof(ShopWindow)), shopWindow.Activate);
            UIEventsTranslator.AddListener(UIEventsTranslator.GetKey(nameof(WalletUI)), wallet.SetData);
            UIEventsTranslator.AddListener(UIEventsTranslator.GetKey(nameof(ItemsWindow)), itemsWindow.Init);
            UIEventsTranslator.AddListener(UIEventsTranslator.GetKey(nameof(GameOverWindow)), gameOver.Activate);
            UIEventsTranslator.AddListener(UIEventsTranslator.GetKey(nameof(WindowsManager)), CloseAll);
        }

        public void CloseAll()
        {
            miningWindow.Deactivate();
            productionWindow.Deactivate();
            itemsSelector.Deactivate();
            shopWindow.Deactivate();
            gameOver.Deactivate();
        }

        private void OnDestroy()
        {
            UIEventsTranslator.RemoveAllListeners();
        }
    }
}