using System;
using System.Collections.Generic;

namespace Util.Finite_State_Machine
{
    public sealed class FiniteStateMachine : State
    {
        protected override Type CheckTransitions() => null;
    }
}