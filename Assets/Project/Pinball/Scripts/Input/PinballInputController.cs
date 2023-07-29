using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PinballInputController : MonoBehaviour
{
    private PlayerInputActions input;

    private void Awake()
    {
        input = new PlayerInputActions();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    public Vector2 GetInputDirection() => input.Player.Movement.ReadValue<Vector2>();
    public bool Fire() => input.Player.Fire1.IsPressed();
}
