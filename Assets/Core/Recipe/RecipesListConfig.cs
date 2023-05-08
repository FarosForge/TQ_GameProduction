using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "RecipesListConfig", menuName = "GAME/Recipes/RecipesListConfig")]
    public class RecipesListConfig : ScriptableObject
    {
        [SerializeField] private RecipeConfig[] recipes;

        public RecipeConfig[] Recipes { get => recipes; }
    }
}