using System.Collections.Generic;
using UnityEngine;

namespace Util.Tickers {
	// TickerList allows ordering of update calls through Tickers. 
	public sealed class TickerList : MonoBehaviour {
		public List<Ticker> Tickers = new List<Ticker>();

		public void Update() {
			foreach (Ticker ticker in Tickers) ticker.Tick();
		}
	}
}