using Unity.Entities;
using UnityEngine;

namespace SnowBlocks.ecsSnow
{
    public class SnowTagAuthoring : MonoBehaviour
    {
        
    }

    public class SnowTagBaker : Baker<SnowTagAuthoring>
    {
        public override void Bake(SnowTagAuthoring authoring)
        {
            AddComponent(new SnowTag());
        }
    }
}