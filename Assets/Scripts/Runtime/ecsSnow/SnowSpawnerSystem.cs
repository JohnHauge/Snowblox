using Unity.Entities;

namespace SnowBlocks.ecsSnow
{
    public partial class SnowSpawnerSystem : SystemBase
    {
        protected override void OnStartRunning()
        {
            base.OnStartRunning();
            var snowEntityQuery = EntityManager.CreateEntityQuery(typeof(SnowTag));
            var randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();
            const int spawnAmount = 10000;

            var snowSpawnerComponent = SystemAPI.GetSingleton<SnowSpawnerComponent>();


            var entityCommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(World.Unmanaged);

            for (int i = 0; i < spawnAmount; i++)
            {
                var spawnedEntity = entityCommandBuffer.Instantiate(snowSpawnerComponent.SnowPrefab);
                entityCommandBuffer.SetComponent(spawnedEntity, new Speed
                {
                    Value = randomComponent.ValueRW.Random.NextFloat(1f, 5f)
                });
            }
        }

        protected override void OnUpdate()
        {
            
        }
    }
}