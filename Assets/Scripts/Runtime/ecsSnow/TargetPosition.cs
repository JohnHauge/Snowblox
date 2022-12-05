using Unity.Entities;
using Unity.Mathematics;

namespace SnowBlocks.ecsSnow
{
    public struct TargetPosition : IComponentData
    {
        public float3 Value;
    }
}