using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using Util.Tickers;

namespace Util.Finite_State_Machine {
	[RequireComponent(typeof(FiniteStateMachine))]
	public abstract class State : Ticker, ISerializationCallbackReceiver {
		public UnityEvent<State> onEnter;
		public UnityEvent<State> onTick;
		public UnityEvent<State> onExit;

		public State parentState;
		[SerializeField] private State currentSubState;

		[SerializeField] private List<State> substateList = new();
		private readonly Dictionary<Type, State> _substateDict = new();

		public void OnBeforeSerialize() { }

		public void OnAfterDeserialize() {
			// load contents from the List into the HashSet
			_substateDict.Clear();
			foreach (State state in substateList) {
				if (state is null) continue;
				state.parentState = this;
				_substateDict[state.GetType()] = state;
			}
		}

		[CanBeNull] // Return null to not transition
		protected abstract Type CheckTransitions();

		protected virtual void EnterImpl() { }

		protected virtual void TickImpl() { }

		protected virtual void ExitImpl() { }

		private void Enter() {
			EnterImpl();
			onEnter.Invoke(this);
		}

		public override void Tick() {
			Transition();
			TickImpl();
			onTick.Invoke(this);
			currentSubState.Tick();
		}

		private void Exit() {
			ExitImpl();
			onExit.Invoke(this);
		}

		private void Transition() {
			Type stateType = CheckTransitions();
			if (!(stateType is null)) parentState.SetState(stateType);
		}

		private void SetState(Type stateType) {
			if (_substateDict.ContainsKey(stateType)) {
				currentSubState.Exit();
				currentSubState = _substateDict[stateType];
				currentSubState.Enter();
				currentSubState.Tick(); // should we tick here? revisit later
			}
			else {
				string typeName = stateType.FullName;
				Debug.LogError("State " + typeName + " isn't in this machine");
			}
		}
	}
}