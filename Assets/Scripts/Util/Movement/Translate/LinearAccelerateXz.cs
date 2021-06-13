using UnityEngine;

namespace Util.Movement.Translate {
public class LinearAccelerateXz : LinearAccelerate {
    public override Vector3 Modify(Vector3 val) {
        return val.MoveTowardsXz(Target, Speed(val) * Time.deltaTime);
    }
}
}