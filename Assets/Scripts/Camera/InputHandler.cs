using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class InputHandler : MonoBehaviour, AxisState.IInputAxisProvider
{
    [HideInInspector] public InputAction _horizontal;
    [HideInInspector] public InputAction _vertical;


    /// <summary>
    /// This is an add-on to override the legacy input system and read input using the
    /// UnityEngine.Input package API.  Add this behaviour to any CinemachineVirtualCamera 
    /// or FreeLook that requires user input, and drag in the the desired actions.
    /// </summary>
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