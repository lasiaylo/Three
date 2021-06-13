using UnityEngine;

namespace Util.Movement.Rotation
{
    public class TurnTowards : Mod<Quaternion>
    {
        public Vector3 Direction { private get; set; }
        [SerializeField] private float turnSpeed = default; 

        public override Quaternion Modify(Quaternion val)
        {
            return Direction.IsZero()
                ? val
                : Quaternion.RotateTowards(
                    val,
                    Quaternion.LookRotation(Direction),
                    turnSpeed * Time.deltaTime
                );
        }
    }
}