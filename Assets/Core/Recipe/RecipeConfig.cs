using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "GAME/Recipes/New Recipe")]
public class RecipeConfig : ScriptableObject
{
    [SerializeField] private ItemConfig[] resources;
    [SerializeField] private ItemConfig resultItem;

    public ItemConfig[] Resources { get => resources; }

    public ItemConfig GetResult(string[] res)
    {
        int v = 0;

        foreach (var item in resources)
        {
            foreach (var val in res)
            {
                if(item.ID == val)
                {
                    v++;
                    break;
                }
            }
        }

        if(v == resources.Length)
        {
            return resultItem;
        }

        return null;
    }
}
