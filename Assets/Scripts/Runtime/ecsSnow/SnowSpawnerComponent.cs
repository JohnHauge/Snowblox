using Unity.Entities;
using UnityEngine;

namespace SnowBlocks.ecsSnow
{
    public struct SnowSpawnerComponent : IComponentData
    {
        public Entity SnowPrefab;
    }
}