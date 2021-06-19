using System;
using UnityEngine;

namespace Util.Tickers {
	public abstract class Ticker : MonoBehaviour {
		public abstract void Tick();

		public void OnEnable() { }
	}
}