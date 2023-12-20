using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EmoteWheel : MonoBehaviour
{

    private CharacterMovement charMoveScript;
    [SerializeField] private PlayerInput input;
    private Animator animator;
    private InputAction isDownAction, isLeftAction, isRightAction, isUpAction;

    int DpadDownHash;
    int DpadLeftHash;
    int DpadRightHash;
    int DpadUpHash;

    bool UpPressed = false;
    bool DownPressed = false;
    bool LeftPressed = false;
    bool RightPressed = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        charMoveScript = GetComponent<CharacterMovement>();

        isDownAction = new InputAction("Down", binding: "<Gamepad>/dpad/down");
        isDownAction.AddBinding("<Keyboard>/1");
        isDownAction.performed += ctx => Down();
        isLeftAction = new InputAction("Left", binding: "<Gamepad>/dpad/left");
        isLeftAction.AddBinding("<Keyboard>/2");
        isLeftAction.performed += ctx => Left();
        isRightAction = new InputAction("Right", binding: "<Gamepad>/dpad/right");
        isRightAction.AddBinding("<Keyboard>/3");
        isRightAction.performed += ctx => Right();
        isUpAction = new InputAction("Up", binding: "<Gamepad>/dpad/up");
        isUpAction.AddBinding("<Keyboard>/4");
        isUpAction.performed += ctx => Up();
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
        handleEmotes();
    }

    private void handleEmotes()
    {
        //Summary: New variables are filled with a bool that was created in the player's Animator, after that it checks to see if the left-stick is being moved currently -
        //and if it is being moved it cancels the emote and goes into the walking/running animation
        bool DpadDown = animator.GetBool(DpadDownHash);
        bool DpadLeft = animator.GetBool(DpadLeftHash);
        bool DpadRight = animator.GetBool(DpadRightHash);
        bool DpadUp = animator.GetBool(DpadUpHash);

        if (charMoveScript.MovePressed() == false)
        {
            //Debug.Log("Currently not moving");
            if (DownPressed && !DpadDown)
            {
                animator.SetBool(DpadDownHash, true);
                //Debug.Log("Play down animation");
            }

            if (LeftPressed && !DpadLeft)
            {
                animator.SetBool(DpadLeftHash, true);
                //Debug.Log("Play Left animation");
            }

            if (RightPressed && !DpadRight)
            {
                animator.SetBool(DpadRightHash, true);
                //Debug.Log("Play Right animation");

            }

            if (UpPressed && !DpadUp)
            {
                animator.SetBool(DpadUpHash, true);
                //Debug.Log("Play Up animation");
            }
        }
        else
        {
            animator.SetBool(DpadUpHash, false);
            animator.SetBool(DpadDownHash, false);
            animator.SetBool(DpadLeftHash, false);
            animator.SetBool(DpadRightHash, false);
            UpPressed = false;
            DownPressed = false;
            LeftPressed = false;
            RightPressed = false;
            //Debug.Log("Turn anims off");
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
        DownPressed = true;
        animator.Play("Gangnam Style");
    }
    private void Left()
    {
        LeftPressed = true;
        animator.Play("Hip Hop Dancing");
    }
    private void Right()
    {
        RightPressed = true;
        animator.Play("Back Flip To Uppercut");
    }
    private void Up()
    {
        UpPressed = true;
        animator.Play("Salsa Dance");
    }
}
