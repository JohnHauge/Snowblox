using Unity.Entities;

namespace SnowBlocks.ecsSnow
{
    public struct RandomComponent : IComponentData
    {
        public Unity.Mathematics.Random Random;
    }
}