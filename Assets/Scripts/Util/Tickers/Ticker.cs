using UnityEngine;

namespace Util.Tickers
{
    public abstract class Ticker: MonoBehaviour
    {
        public abstract void Tick();
    }
}