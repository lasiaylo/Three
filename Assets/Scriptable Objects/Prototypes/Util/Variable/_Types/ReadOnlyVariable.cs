using UnityEngine;

public abstract class ReadOnlyVariable<T> : ScriptableObject {
	[SerializeField] protected T _val;

	public T Val => _val;
}