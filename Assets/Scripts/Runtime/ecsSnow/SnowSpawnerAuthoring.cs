using Unity.Entities;
using UnityEngine;

namespace SnowBlocks.ecsSnow
{
    public class SnowSpawnerAuthoring : MonoBehaviour
    {
        public GameObject snowPrefab;
    }

    public class SnowSpawnerBaker : Baker<SnowSpawnerAuthoring>
    {
        public override void Bake(SnowSpawnerAuthoring authoring)
        {
            AddComponent ( new SnowSpawnerComponent 
            {
                SnowPrefab = GetEntity(authoring.snowPrefab),
            });
        }
    }
}