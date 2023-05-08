using Config;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SceneScriptableInstaller", menuName = "Installers/SceneScriptableInstaller")]
public class SceneScriptableInstaller : ScriptableObjectInstaller<SceneScriptableInstaller>
{
    [SerializeField] private RecipesListConfig recipesList;
    [SerializeField] private ItemsContainerConfig itemsContainer;
    [SerializeField] private BuildingsContainerConfig buildingsContainer;
    [SerializeField] private GameModesListConfig gameModes;

    public override void InstallBindings()
    {
        Container.BindInstances
        (
            recipesList,
            itemsContainer,
            buildingsContainer,
            gameModes
        );
    }
}