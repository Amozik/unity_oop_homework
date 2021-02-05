using UnityEngine;

namespace General
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        public PlayerBall playerPrefab;
        public LevelConfig levelConfig;
        public UiConfig uiConfig;
    }
}