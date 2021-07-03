using System;
using System.Collections.Generic;
using System.Linq;
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
		[SerializeField, CanBeNull] protected State currentSubstate;

		[SerializeField] protected List<State> substateList = new List<State>();
		private readonly Dictionary<Type, State> _substateDict = new Dictionary<Type, State>();

		[CanBeNull] // Return null to not transition
		protected abstract Type CheckTransitions();

		[CanBeNull] // Called to figure out which substate to land on
		protected virtual Type CheckSubTransitions() {
			return substateList.FirstOrDefault()?.GetType();
		}

		protected virtual void EnterImpl() { }
		protected virtual void TickImpl() { }
		protected virtual void ExitImpl() { }


		protected internal void Enter() {
			SubTransition();
			EnterImpl();
			onEnter.Invoke(this);
		}

		public override void Tick() {
			if (!enabled) return; // Maybe refactor out
			Transition();
			TickImpl();
			onTick.Invoke(this);
			currentSubstate?.Tick();
		}

		private void Exit() {
			ExitImpl();
			onExit.Invoke(this);
		}

		private void Transition() {
			Type type = CheckTransitions();
			if (type is null) return;

			parentState.SetSubstate(type);
		}

		private void SubTransition() {
			Type type = CheckSubTransitions();
			if (type is null) return;
			
			SetSubstate(type);
		}
		
		private void SetSubstate(Type stateType) {
			if (_substateDict.ContainsKey(stateType)) {
				currentSubstate.Exit();
				currentSubstate = _substateDict[stateType];
				currentSubstate.Enter();
				currentSubstate.Tick(); // should we tick here? revisit later
			}
			else {
				string typeName = stateType.FullName;
				Debug.LogError("State " + typeName + " isn't in this machine");
			}
		}

		public virtual void OnBeforeSerialize() { }

		public void OnAfterDeserialize() {
			// load contents from the List into the HashSet
			_substateDict.Clear();
			foreach (State state in substateList) {
				if (state is null) continue;
				state.parentState = this;
				_substateDict[state.GetType()] = state;
			}
		}
	}
}