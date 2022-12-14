using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace SnowBlocks.ecsSnow
{
    [BurstCompile]
    public partial struct MovingISystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var random = SystemAPI.GetSingletonRW<RandomComponent>();
            var deltaTime = SystemAPI.Time.DeltaTime;
            var jobHandle = new MoveJob
            {
                DeltaTime = deltaTime
            }.ScheduleParallel(state.Dependency); 
            
            jobHandle.Complete();
            
            new TestReachedTargetPositionJob()
            {
                
                RandomComponent = random
            }.Run();
        }
    }
    
    [BurstCompile]
    public partial struct MoveJob : IJobEntity
    {
        public float DeltaTime;

        [BurstCompile]
        public void Execute(MoveToPositionAspect moveToPositionAspect)
        {
            moveToPositionAspect.Move(DeltaTime);
        }
    }

    [BurstCompile]
    public partial struct TestReachedTargetPositionJob : IJobEntity
    {
        [NativeDisableUnsafePtrRestriction] public RefRW<RandomComponent> RandomComponent;
        [BurstCompile]
        public void Execute(MoveToPositionAspect moveToPositionAspect)
        {
            moveToPositionAspect.TestReachTargetPosition(RandomComponent);
        }
    }
}

