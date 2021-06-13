
namespace FSM.Movement
{
    public struct MovementTraits
    {
        public float Acceleration;
        public float Deceleration;
        public float MaxSpeed;
    }

    public interface IHasMovementTraits
    {
        MovementTraits MovementTraits { get; }
    }
}