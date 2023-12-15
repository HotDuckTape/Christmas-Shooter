using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EmoteWheel : MonoBehaviour
{
    [SerializeField] private List<AnimationClip> emoteAnims = new List<AnimationClip>();
    [SerializeField] private PlayerInput input;
    private Animator animator;
    private InputAction isDownAction, isLeftAction, isRightAction, isUpAction;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        isDownAction = new InputAction("Down", binding: "<Gamepad>/dpad/down");
        isDownAction.performed += ctx => Down();
        isLeftAction = new InputAction("Left", binding: "<Gamepad>/dpad/left");
        isLeftAction.performed += ctx => Left();
        isRightAction = new InputAction("Right", binding: "<Gamepad>/dpad/right");
        isRightAction.performed += ctx => Right();
        isUpAction = new InputAction("Up", binding: "<Gamepad>/dpad/up");
        isUpAction.performed += ctx => Up();
    }

    private void OnEnable()
    {
        isDownAction.Enable();
        isLeftAction.Enable();
        isRightAction.Enable();
        isUpAction.Enable();
    }

    private void OnDisable()
    {
        isDownAction.Disable();
        isLeftAction.Disable();
        isRightAction.Disable();
        isUpAction.Disable();
    }

    private void Down()
    {
        animator.Play(emoteAnims[0].name);
    }
    private void Left()
    {
        animator.Play(emoteAnims[1].name);
    }
    private void Right()
    {
        animator.Play(emoteAnims[2].name);
    }
    private void Up()
    {
        animator.Play(emoteAnims[3].name);
    }
}
