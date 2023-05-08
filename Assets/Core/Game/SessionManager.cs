using Building;
using Config;
using Global.Wallet;
using Item;
using Save;
using System;
using UI;
using UnityEngine;
using Zenject;

namespace Game
{
    public class SessionManager : MonoBehaviour
    {
        [SerializeField] private BuildingsViewContainer buildingsView;

        private ItemsContainerConfig itemsConfig;
        private BuildingsContainerConfig buildingsConfig;
        private RecipesListConfig recipesList;
        private ItemsContainer itemsContainer;
        private BuildingsContainer buildingsContainer;
        private Wallet wallet;
        private SaveSystem saveSystem;
        private GameModesListConfig gameModes;

        [Inject]
        public void Construct(BuildingsContainerConfig buildingsConfig, ItemsContainerConfig itemsConfig,
            RecipesListConfig recipesList, SaveSystem saveSystem, GameModesListConfig gameModes)
        {
            this.buildingsConfig = buildingsConfig;
            this.itemsConfig = itemsConfig;
            this.recipesList = recipesList;
            this.saveSystem = saveSystem;
            this.gameModes = gameModes;
        }

        public BuildingsContainer BuildingsContainer { get => buildingsContainer; }
        public ItemsContainer ItemsContainer { get => itemsContainer; }
        public RecipesListConfig RecipesList { get => recipesList; }
        public BuildingsContainerConfig BuildingsConfig { get => buildingsConfig; }
        public BuildingsViewContainer BuildingsView { get => buildingsView; }
        public Wallet Wallet { get => wallet; }

        public void Init(Action postInit)
        {

            saveSystem.Load();

            itemsContainer = new ItemsContainer(itemsConfig, saveSystem);
            itemsContainer.Init();
            buildingsContainer = new BuildingsContainer(this);
            wallet = new Wallet();
            wallet.Init(saveSystem);
            wallet.GetCurrency(CurrencyType.Gold).PostAddedValue += CheckToGameOver;

            UIEventsTranslator.Call(UIEventsTranslator.GetKey(nameof(WalletUI)),
                new WalletUIData(Wallet.GetCurrency(CurrencyType.Gold).GetValue()));

            UIEventsTranslator.Call(UIEventsTranslator.GetKey(nameof(ItemsWindow)));

            postInit?.Invoke();
        }

        private void OnDestroy()
        {
            wallet.GetCurrency(CurrencyType.Gold).PostAddedValue -= CheckToGameOver;
        }

        public void SetGameMode(int val)
        {
            buildingsView.SetActiveResourceBuildings(val);
        }

        public void CheckToGameOver()
        {
            if (wallet.GetCurrency(CurrencyType.Gold).GetValue() < gameModes.GoldCountToGameOver)
                return;

            Debug.Log("Game Complete");
            buildingsContainer.StopAllBuildings();
            UIEventsTranslator.Call(UIEventsTranslator.GetKey(nameof(WindowsManager)));
            UIEventsTranslator.Call(UIEventsTranslator.GetKey(nameof(GameOverWindow)));
        }
    }
}