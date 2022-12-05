using Unity.Entities;
using UnityEngine;

namespace SnowBlocks.ecsSnow
{
    public class SpeedAuthoring : MonoBehaviour
    {
        public float value;
        
        
    }

    public class SpeedBaker : Baker<SpeedAuthoring>
    {
        public override void Bake(SpeedAuthoring authoring)
        {
            AddComponent(new Speed
            {
                Value = authoring.value
            });
        }
    }
}