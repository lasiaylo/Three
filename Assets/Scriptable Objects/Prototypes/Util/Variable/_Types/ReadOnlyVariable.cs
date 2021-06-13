using UnityEngine;

public abstract class ReadOnlyVariable<T> : ScriptableObject {
    [SerializeField] protected T _val = default;

    public T Val {
        get => _val;
    }
}