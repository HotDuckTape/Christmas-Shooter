using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EmoteWheel : MonoBehaviour
{

    [SerializeField] private PlayerInput _input;
    private CharacterMovement _charMoveScript;
    private Animator _animator;
    private InputAction _isDownAction, _isLeftAction, _isRightAction, _isUpAction;

    int _DpadDownHash;
    int _DpadLeftHash;
    int _DpadRightHash;
    int _DpadUpHash;

    bool _UpPressed = false;
    bool _DownPressed = false;
    bool _LeftPressed = false;
    bool _RightPressed = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _charMoveScript = GetComponent<CharacterMovement>();

        _isDownAction = new InputAction("Down", binding: "<Gamepad>/dpad/down");
        _isDownAction.AddBinding("<Keyboard>/1");
        _isDownAction.performed += ctx => Down();
        _isLeftAction = new InputAction("Left", binding: "<Gamepad>/dpad/left");
        _isLeftAction.AddBinding("<Keyboard>/2");
        _isLeftAction.performed += ctx => Left();
        _isRightAction = new InputAction("Right", binding: "<Gamepad>/dpad/right");
        _isRightAction.AddBinding("<Keyboard>/3");
        _isRightAction.performed += ctx => Right();
        _isUpAction = new InputAction("Up", binding: "<Gamepad>/dpad/up");
        _isUpAction.AddBinding("<Keyboard>/4");
        _isUpAction.performed += ctx => Up();
    }

    private void Start()
    {
        _DpadDownHash = Animator.StringToHash("DpadDown");
        _DpadLeftHash = Animator.StringToHash("DpadLeft");
        _DpadRightHash = Animator.StringToHash("DpadRight");
        _DpadUpHash = Animator.StringToHash("DpadUp");
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
        bool DpadDown = _animator.GetBool(_DpadDownHash);
        bool DpadLeft = _animator.GetBool(_DpadLeftHash);
        bool DpadRight = _animator.GetBool(_DpadRightHash);
        bool DpadUp = _animator.GetBool(_DpadUpHash);

        if (_charMoveScript.MovePressed() == false)
        {
            //Debug.Log("Currently not moving");
            if (_DownPressed && !DpadDown)
            {
                _animator.SetBool(_DpadDownHash, true);
                //Debug.Log("Play down animation");
            }

            if (_LeftPressed && !DpadLeft)
            {
                _animator.SetBool(_DpadLeftHash, true);
                //Debug.Log("Play Left animation");
            }

            if (_RightPressed && !DpadRight)
            {
                _animator.SetBool(_DpadRightHash, true);
                //Debug.Log("Play Right animation");

            }

            if (_UpPressed && !DpadUp)
            {
                _animator.SetBool(_DpadUpHash, true);
                //Debug.Log("Play Up animation");
            }
        }
        else
        {
            _animator.SetBool(_DpadUpHash, false);
            _animator.SetBool(_DpadDownHash, false);
            _animator.SetBool(_DpadLeftHash, false);
            _animator.SetBool(_DpadRightHash, false);
            _UpPressed = false;
            _DownPressed = false;
            _LeftPressed = false;
            _RightPressed = false;
            //Debug.Log("Turn anims off");
        }
    }

    private void OnEnable()
    {
        _isDownAction.Enable();
        _isLeftAction.Enable();
        _isRightAction.Enable();
        _isUpAction.Enable();
    }

    private void OnDisable()
    {
        _isDownAction.Disable();
        _isLeftAction.Disable();
        _isRightAction.Disable();
        _isUpAction.Disable();
    }
    //The 4 functions under this are supposed to play the animation when pressing the corresponding D-pad button which DOES work. The StopAnims function does NOT seem to stop the emotes from playing however
    private void Down()
    {
        _DownPressed = true;
        _animator.Play("Gangnam Style");
    }
    private void Left()
    {
        _LeftPressed = true;
        _animator.Play("Hip Hop Dancing");
    }
    private void Right()
    {
        _RightPressed = true;
        _animator.Play("Back Flip To Uppercut");
    }
    private void Up()
    {
        _UpPressed = true;
        _animator.Play("Salsa Dance");
    }
}
