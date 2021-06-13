using System;
using System.Collections.Generic;
using FSM.Movement;
using UnityEngine.Events;

namespace Util.Finite_State_Machine
{
    public class GroundState: State, IHasMovementTraits
    {
        public MovementTraits MovementTraits { get; }
        protected override Type CheckTransitions()
        {
            throw new NotImplementedException();
        }
    }
}