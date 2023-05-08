using UnityEngine;

[CreateAssetMenu(fileName = "GameModesListConfig", menuName = "GAME/GameModesListConfig")]
public class GameModesListConfig : ScriptableObject
{
    [SerializeField] private GameModeRef[] list;

    public GameModeRef[] List { get => list; }
}

[System.Serializable]
public struct GameModeRef
{
    public int ResourceBuildsCount;
}
