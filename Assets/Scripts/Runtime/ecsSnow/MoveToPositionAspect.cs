
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace SnowBlocks.ecsSnow
{
    public readonly partial struct MoveToPositionAspect : IAspect
    {
        private readonly Entity _entity;
        
        private readonly TransformAspect _transformAspect;
        private readonly RefRO<Speed> _speed;
        private readonly RefRW<TargetPosition> _targetPosition;

        public void Move(float deltaTime)
        {
            //dir
            var dir = math.normalize(Vector3.down);
            //move
            _transformAspect.Position += dir * deltaTime * _speed.ValueRO.Value;
        }

        public void TestReachTargetPosition(RefRW<RandomComponent> random)
        {
            var reachTargetDistance = .5f;
            if (_transformAspect.Position.y <= 0f)
            {
                _transformAspect.Position = GetRandomPosition(random);
            }
            if (math.distance(_transformAspect.Position.y, 0f) < reachTargetDistance)
            {
                _targetPosition.ValueRW.Value = GetRandomPosition(random);
            }
        }

        private float3 GetRandomPosition(RefRW<RandomComponent> random)
        {
            return new float3
            {
                x = random.ValueRW.Random.NextFloat(-50f, 50f),
                y = random.ValueRW.Random.NextFloat(7f, 15f),
                z = random.ValueRW.Random.NextFloat(-50f, 50f)
            };
        }
    }
}