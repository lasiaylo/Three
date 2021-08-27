using System;
using UnityEngine;

namespace Movement.Translate {
	/// <summary>
	///     Handles GameObject Movement.
	/// </summary>
	/// <remarks>
	///     Source: Dapper Dino's Design
	///     https://github.com/DapperDino/Dapper-Tools/tree/master/Runtime/Components/Movements
	/// </remarks>
	public class MovementModifier : Modifier<Vector3> {
		protected override Type ComponentType => typeof(MovementMod);

		public Vector3 Value {
			get => enabled ? val : Vector3.zero;
			private set => val = value;
		}
	}
}