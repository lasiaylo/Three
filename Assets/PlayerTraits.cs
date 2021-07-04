using Scriptable_Objects.Prototypes.Traits;
using Scriptable_Objects.Prototypes.Util.Variable.Default;
using UnityEngine;

// Centralizes all traits about the player
// This is bad code :)
public class PlayerTraits : MonoBehaviour {
	public DefaultMovementTraits movement;
	public DefaultJumpTraits jump;
	public DefaultDirection direction;
}