using System;
using UnityEngine;

namespace Garden.Factors {
	[Serializable]
	public abstract class Need : MonoBehaviour {
		public float Value { get; private set; }
		public abstract float CheckConditions();
	}
}