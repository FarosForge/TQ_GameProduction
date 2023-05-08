using Game;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "GameModesListConfig", menuName = "GAME/GameModesListConfig")]
    public class GameModesListConfig : ScriptableObject
    {
        [SerializeField] private GameModeRef[] list;
        [SerializeField] private int goldCountToGameOver;

        public GameModeRef[] List { get => list; }
        public int GoldCountToGameOver { get => goldCountToGameOver; }

    }
}
