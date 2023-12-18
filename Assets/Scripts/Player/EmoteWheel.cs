using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EmoteWheel : MonoBehaviour
{

    private CharacterMovement charMoveScript;
    [SerializeField] private PlayerInput input;
    private Animator animator;
    private InputAction isDownAction, isLeftAction, isRightAction, isUpAction, stopEmote;

    int DpadDownHash;
    int DpadLeftHash;
    int DpadRightHash;
    int DpadUpHash;

    bool UpPressed;
    bool DownPressed;
    bool LeftPressed;
    bool RightPressed;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        charMoveScript = GetComponent<CharacterMovement>();

        isDownAction = new InputAction("Down", binding: "<Gamepad>/dpad/down");
        isDownAction.performed += ctx => Down();
        isLeftAction = new InputAction("Left", binding: "<Gamepad>/dpad/left");
        isLeftAction.performed += ctx => Left();
        isRightAction = new InputAction("Right", binding: "<Gamepad>/dpad/right");
        isRightAction.performed += ctx => Right();
        isUpAction = new InputAction("Up", binding: "<Gamepad>/dpad/up");
        isUpAction.performed += ctx => Up();
        //stopEmote = new InputAction("Button East", binding: "<Gamepad>/buttonEast");
        //stopEmote.performed += ctx => StopAnims();
    }

    private void Start()
    {
        DpadDownHash = Animator.StringToHash("DpadDown");
        DpadLeftHash = Animator.StringToHash("DpadLeft");
        DpadRightHash = Animator.StringToHash("DpadRight");
        DpadUpHash = Animator.StringToHash("DpadUp");

    }

    private void Update()
    {
        //Currently not in use
        //handleEmotes();
    }

    private void handleEmotes()
    {
        //Summary: New variables are filled with a bool that was created in the player's Animator, after that it checks to see if the left-stick is being moved currently -
        //and if it is being moved it is *supposed to* cancel the emote and go into the walking animation but it is currently not doing that
        //The booleans are also not being set to true OR false in the animator, so it isn't affecting them either despite having conditions on the animations
        bool DpadDown = animator.GetBool(DpadDownHash);
        bool DpadLeft = animator.GetBool(DpadLeftHash);
        bool DpadRight = animator.GetBool(DpadRightHash);
        bool DpadUp = animator.GetBool(DpadUpHash);

        if (charMoveScript.MovePressed() != true)
        {
            if (DownPressed && !DpadDown) animator.SetBool(DpadDownHash, true);

            if (LeftPressed && !DpadLeft) animator.SetBool(DpadLeftHash, true);

            if (RightPressed && !DpadRight) animator.SetBool(DpadRightHash, true);

            if (UpPressed && !DpadUp) animator.SetBool(DpadUpHash, true);
        }
        else
        {
            animator.SetBool(DpadUpHash, false);
            animator.SetBool(DpadDownHash, false);
            animator.SetBool(DpadLeftHash, false);
            animator.SetBool(DpadRightHash, false);
        }
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
    //The 4 functions under this are supposed to play the animation when pressing the corresponding D-pad button which DOES work. The StopAnims function does NOT seem to stop the emotes from playing however
    private void Down()
    {
        animator.Play("Gangnam Style");
    }
    private void Left()
    {
        animator.Play("Hip Hop Dancing");
    }
    private void Right()
    {
        animator.Play("Back Flip To Uppercut");
    }
    private void Up()
    {
        animator.Play("Salsa Dance");
    }

    private void StopAnims()
    {
        animator.StopPlayback();
    }
}
