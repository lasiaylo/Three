using UnityEngine;

namespace Util.Movement.Translate {
/// <summary>
///     Handles GameObject Movement.
/// </summary>
/// <remarks>
///     Source: Dapper Dino's Design
///     https://github.com/DapperDino/Dapper-Tools/tree/master/Runtime/Components/Movements
/// </remarks>
[RequireComponent(typeof(CharacterController))]
public class MovementTicker : Modifier<Vector3> {
    private CharacterController _controller;

    public Vector3 Value {
        get => enabled ? val : Vector3.zero;
        private set => val = value;
    }

    public void Awake() {
        _controller = GetComponent<CharacterController>();
    }

    public override void Tick() {
        base.Tick();
        _controller.Move(val * Time.deltaTime);
    }
}
}