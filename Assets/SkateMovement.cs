using Movement.Translate;
using Scriptable_Objects.Prototypes.Util.Variable.Default;
using ScriptableObjects.Prototypes.Variable;
using UnityEngine;

public class SkateMovement : MovementMod {
    [SerializeField] private float friction;
    [SerializeField] private float veerInfluence;
    [SerializeField] private DefaultNormalVector2 inputDirection = default;
    [SerializeField] private DefaultBool push = default;
    // TODO: Include jumpphase
    
    public override Vector3 Modify(Vector3 val) {
        throw new System.NotImplementedException();
    }
}
