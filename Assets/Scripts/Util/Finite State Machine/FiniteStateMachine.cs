using System;
using System.Linq;
using UnityEngine;

namespace Util.Finite_State_Machine {
	public sealed class FiniteStateMachine : State, ISerializationCallbackReceiver {
		public void Awake() {
			currentSubstate = substateList.FirstOrDefault();
			currentSubstate?.Enter();
		}

		public void Update() {
			Tick();
		}

		protected override Type CheckTransitions() {
			return null;
		}
		
		public void OnBeforeSerialize() {
			substateList = GetComponents<State>().ToList();
			substateList.Remove(this);
		}

		public void OnAfterDeserialize() { }
	}
}