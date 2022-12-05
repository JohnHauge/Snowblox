using Unity.Entities;
using UnityEngine;

namespace SnowBlocks.ecsSnow
{
    public class RandomAuthoring : MonoBehaviour
    {
        
    }

    public class RandomBaker : Baker<RandomAuthoring>
    {
        public override void Bake(RandomAuthoring authoring)
        {
            AddComponent(new RandomComponent
            {
                Random = new Unity.Mathematics.Random(1)
            });
        }
    }
}