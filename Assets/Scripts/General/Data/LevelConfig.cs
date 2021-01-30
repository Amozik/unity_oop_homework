using UnityEngine;

namespace General
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        public int totalPoints;
        public GameObject prefab;
    }
}