using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipesListConfig", menuName = "GAME/Recipes/RecipesListConfig")]
public class RecipesListConfig : ScriptableObject
{
    [SerializeField] private RecipeConfig[] recipes;

    public RecipeConfig[] Recipes { get => recipes; }
}
