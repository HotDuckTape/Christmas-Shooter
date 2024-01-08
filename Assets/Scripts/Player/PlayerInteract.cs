using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    CharacterMovement _charMovementScript;
    EmoteWheel _emoteWheel;
    PlayerInputs _input;

    private Rigidbody _rb;

    private RigidbodyConstraints _rbOriginalConstraints;

    private bool _inCannonMode = false;

    private bool _cannonButtonPressed;

    CinemachineVirtualCamera _cinemachine;

    [SerializeField] InputActionAsset _actionAsset;

    [SerializeField] private CinemachineVirtualCamera _virtualCamera1; //Player camera
    [SerializeField] private CinemachineVirtualCamera _virtualCamera2; //Cannon camera
    
    bool _swapCam = false;

    Coroutine _currentCoroutine1 = null;
    Coroutine _currentCoroutine2 = null;

    private InputActionMap _cannonMode;
    private InputActionMap _cannonButton;

    SkinnedMeshRenderer _meshRenderer;

    bool cannonEntered = false;

    private void Awake()
    {
        _input = new PlayerInputs();
        _input.GameplayControls.CannonControl.performed += ctx => _cannonButtonPressed = ctx.ReadValueAsButton();
        _input.GameplayControls.CannonControl.canceled += ctx => _cannonButtonPressed = false;

        _cannonMode = _actionAsset.FindActionMap("CannonMode");
    }

    void Start()
    {
        _cinemachine = GetComponent<CinemachineVirtualCamera>();
        _charMovementScript = GetComponent<CharacterMovement>();
        _emoteWheel = GetComponent<EmoteWheel>();
        _meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        _rb = GetComponent<Rigidbody>();
        _rbOriginalConstraints = _rb.constraints;
    }

    private void Update()
    {
        //Debug.Log("Cannon button pressed: " + cannonButtonPressed);
        if (_cannonButtonPressed)
        {
            TurnPlayerOffOrOn();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cannon"))
        {
            cannonEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cannon"))
        {
            cannonEntered = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cannon") && _cannonButtonPressed && !_inCannonMode)
        {
            other.gameObject.GetComponent<CannonShoot>().enabled = true;
            other.gameObject.GetComponent<CinemachineVirtualCamera>().enabled = true;
            _virtualCamera1.enabled = false;
            _charMovementScript.enabled = false;
            _emoteWheel.enabled = false;
            _meshRenderer.enabled = false;
            FreezeConstraints();
        }

        if (_cannonButtonPressed && _inCannonMode)
        {
            other.gameObject.GetComponent<CannonShoot>().enabled = false;
            other.gameObject.GetComponent<CinemachineVirtualCamera>().enabled = false;
            _virtualCamera1.enabled = true;
            _charMovementScript.enabled = true;
            _emoteWheel.enabled = true;
            _meshRenderer.enabled = true;
            UnfreezeConstraints();
        }
    }

    IEnumerator SwapToCannonMode(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _inCannonMode = true;
        _currentCoroutine1 = null;
        _currentCoroutine2 = null;
    }

    IEnumerator SwapOutOfCannonMode(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _inCannonMode = false;
        _currentCoroutine1 = null;
        _currentCoroutine2 = null;
    }

    IEnumerator SwapCams()
    {
        //Debug.Log("Should swap");
        //swapCam = true;
        _swapCam = !_swapCam;
        if (_swapCam)
        {
            _virtualCamera1.Priority = 0;
            _virtualCamera2.Priority = 1;
        }
        else
        {
            _virtualCamera1.Priority = 1;
            _virtualCamera2.Priority = 0;
        }

        yield return new WaitForSeconds(1f);
    }

    private void TurnPlayerOffOrOn()
    {
        //Debug.Log("Should start moving into cannon");
        if (_currentCoroutine1 == null)
        {
            if (!_inCannonMode && cannonEntered == true)
            {
                //Move camera with a blend to the cannon
                _currentCoroutine1 = StartCoroutine(SwapCams());
                _currentCoroutine2 = StartCoroutine(SwapToCannonMode(1f));
            }

            if (_cannonButtonPressed && _inCannonMode)
            {
                //Debug.Log("Should start moving OUT of cannon");
                //Move the cam back to the player
                _currentCoroutine1 = StartCoroutine(SwapCams());
                _currentCoroutine2 = StartCoroutine(SwapOutOfCannonMode(1f));
            }
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

    private void FreezeConstraints()
    {
        _rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void UnfreezeConstraints()
    {
        _rb.constraints = _rbOriginalConstraints;
    }
}
