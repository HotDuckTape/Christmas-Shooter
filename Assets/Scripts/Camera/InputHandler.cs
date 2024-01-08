using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class InputHandler : MonoBehaviour, AxisState.IInputAxisProvider
{
    [HideInInspector] public InputAction _horizontal;
    [HideInInspector] public InputAction _vertical;

    public float GetAxisValue(int axis)
    {
        switch (axis)
        {
            case 0: return _horizontal.ReadValue<Vector2>().x;
            case 1: return _horizontal.ReadValue<Vector2>().y;
            case 2: return _vertical.ReadValue<float>();
        }

        return 0;
    }
}