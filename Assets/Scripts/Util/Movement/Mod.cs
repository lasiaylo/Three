using UnityEngine;

namespace Util.Movement {
public abstract class Mod<T> : MonoBehaviour {
    public abstract T Modify(T val);

    /// <summary>
    ///     Left in so enable checkbox appears in Inspector
    /// </summary>
    public void OnEnable() {
    }
}
}