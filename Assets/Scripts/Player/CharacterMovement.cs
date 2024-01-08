using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CharacterMovement : MonoBehaviour
{

    Animator _animator;


    //Variables to store optimized setter/getter parameter IDs
    int _isWalkingHash;
    int _isRunningHash;

    //Variable to store the instance of the PlayerInput
    PlayerInputs _input;

    //Variables to store player input values
    Vector2 _currentMovement;
    Vector2 _rightStickVector;
    bool _movementPressed;
    bool _rightStickMoved;
    bool _runPressed;

    private Transform _cameraTransform;
    private Rigidbody _rb;

    [SerializeField,Range(2f, 8f)] private float _moveSpeed = 2f;

    [SerializeField, Range(3f, 50f)] private float _camTurnSpeed = 10f;

    private void Awake()
    {
        _input = new PlayerInputs();

        //Set the player input values using listeners
        //Sets Movement options, seeing the left analog stick as a vector 2
        _input.GameplayControls.Movement.performed += ctx => {
            _currentMovement = ctx.ReadValue<Vector2>();
            _movementPressed = _currentMovement.x != 0 || _currentMovement.y != 0;
        };

        _input.GameplayControls.Running.performed += ctx => _runPressed = ctx.ReadValueAsButton();

        //Sets Camera options, seeing the right analog stick as a vector 2
        _input.GameplayControls.CamMove.performed += ctx => {
            _rightStickVector = ctx.ReadValue<Vector2>();
            _rightStickMoved = _rightStickVector.x != 0 || _rightStickVector.y != 0;
        };

        //Cancels inouts when not in use aka not moving the sticks
        _input.GameplayControls.Movement.canceled += ctx => _movementPressed = false;
        _input.GameplayControls.CamMove.canceled += ctx => _rightStickMoved = false;

    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        _cameraTransform = Camera.main.transform;

        _isWalkingHash = Animator.StringToHash("isWalking");
        _isRunningHash = Animator.StringToHash("isRunning");
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleCamRotation();
        //Debug.Log("Run button pressed: " + runPressed);
    }

    private void FixedUpdate()
    {
        Vector3 moveIt = new Vector3(_currentMovement.x, 0f, _currentMovement.y) * _moveSpeed * Time.deltaTime;
        _rb.MovePosition(_rb.position + moveIt);
    }

    private void HandleRotation()
    {
        //Current position of the player
        Vector3 currentPosition = transform.position;

        //The change in position the player should point to
        Vector3 newPosition = new Vector3(_currentMovement.x, 0, _currentMovement.y);
        //newPosition = newPosition.x * cameraTransform.right.normalized + newPosition.z * cameraTransform.forward.normalized;
        //newPosition.y = 0f;
        //Combine the positions to give a position to look at
        Vector3 positionToLookAt = currentPosition + newPosition;

        transform.LookAt(positionToLookAt);
    }

    private void HandleCamRotation()
    {
        Vector2 lookInput = _rightStickVector;

        float horizontalRotation = lookInput.x * _camTurnSpeed * Time.deltaTime;

        _cameraTransform.Rotate(Vector3.up, horizontalRotation);
    }

    private void HandleMovement()
    {
        bool isWalking = _animator.GetBool(_isWalkingHash);
        bool isRunning = _animator.GetBool(_isRunningHash);

        //Start walking if movement pressed is true and not already walking
        if (_movementPressed && !isWalking)
        {
            _animator.SetBool(_isWalkingHash, true);
        }

        //Stop walking if movement pressed is false and not already walking
        if (!_movementPressed && isWalking)
        {
            _animator.SetBool(_isWalkingHash, false);
        }

        if ((_movementPressed && _runPressed) && !isRunning)
        {
            _animator.SetBool(_isRunningHash, true);
        }

        if ((!_movementPressed || !_runPressed) && isRunning)
        {
            _animator.SetBool(_isRunningHash, false);
        }
    }

    private void OnEnable()
    {
        _input.GameplayControls.Enable();
    }

    private void OnDisable()
    {
        _input.GameplayControls.Disable();
    }

    public bool MovePressed()
    {
        return _movementPressed;
    }
}
