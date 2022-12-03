using UnityEngine;

namespace SnowBlocks
{
    [CreateAssetMenu(fileName = "SnowSettings", menuName = "SnowBlocks/Settings", order = 0)]
    public class SnowSettings : ScriptableObject
    {
        public int snowAmount;
        public int minHorizontalSpawn;
        public int maxHorizontalSpawn;
        public int minVerticalSpawn;
        public int maxVerticalSpawn;
    }
}