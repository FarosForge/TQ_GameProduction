using Global.Wallet;
using System;
using UI;
using UnityEngine;
using Zenject;

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

    [Inject]
    public void Construct(BuildingsContainerConfig buildingsConfig, ItemsContainerConfig itemsConfig,
        RecipesListConfig recipesList, SaveSystem saveSystem)
    {
        this.buildingsConfig = buildingsConfig;
        this.itemsConfig = itemsConfig;
        this.recipesList = recipesList;
        this.saveSystem = saveSystem;
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

        UIEventsTranslator.Call(UIEventsTranslator.GetKey(nameof(WalletUI)),
            new WalletUIData(Wallet.GetCurrency(CurrencyType.Gold).GetValue()));

        UIEventsTranslator.Call(UIEventsTranslator.GetKey(nameof(ItemsWindow)));

        postInit?.Invoke();
    }

    public void SetGameMode(int val)
    {
        buildingsView.SetActiveResourceBuildings(val);
    }
}
