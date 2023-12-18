using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerInput input;

    private InputActionMap actionMap1;
    private InputActionMap actionMap2;

    [SerializeField] private InputActionAsset actionAsset;
    private void Awake()
    {
        input = new PlayerInput();

        actionMap1 = actionAsset.FindActionMap("GameplayControls");
        actionMap2 = actionAsset.FindActionMap("CannonMode");

    }

    public void SwitchToActionMap(string actionMapName)
    {
        // Enable the desired action map
        if (actionMapName == "GameplayControls")
        {
            actionMap1.Enable();
        }
        else if (actionMapName == "CannonMode")
        {
            actionMap2.Enable();
        }
    }

    public void TurnOffActionMap(string actionMapName)
    {
        actionAsset.FindActionMap(actionMapName).Disable();
    }

    private void OnEnable()
    {
        input.GameplayControls.Enable();
        input.CannonMode.Enable();
    }

    private void OnDisable()
    {
        input.GameplayControls.Disable();
        input.CannonMode.Disable();
    }

}
