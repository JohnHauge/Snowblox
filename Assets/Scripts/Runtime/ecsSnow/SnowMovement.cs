using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace SnowBlocks.ecsSnow
{
    public class SnowMovement
    {
        //Snow movement step in time delta time
        public Vector3 SnowStep(float timeDelta, Vector3 snowPosition, Vector3 snowVelocity)
        {
            Vector3 snowStep = snowVelocity * timeDelta;
            snowPosition += snowStep;
            return snowPosition;
        }
    }
}