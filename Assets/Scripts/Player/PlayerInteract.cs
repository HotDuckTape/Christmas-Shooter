using Unity.Cinemachine;
using System.Collections;

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour, ISwapView
{
    CharacterMovement _charMovementScript;
    EmoteWheel _emoteWheel;
    PlayerInputs _input;

    private Rigidbody _rb;

    private RigidbodyConstraints _rbOriginalConstraints;

    private bool _inCannonMode = false;

    private bool _cannonButtonPressed;

    CinemachineCamera _cinemachine;

    InputActionAsset _actionAsset;

    [SerializeField] private CinemachineCamera _virtualCamera1; //Player camera
    [SerializeField] private CinemachineCamera _virtualCamera2; //Cannon camera
    
	bool _swapCam = false;

    Coroutine _currentCoroutine1 = null;
    Coroutine _currentCoroutine2 = null;

    private InputActionMap player;
    private InputActionMap _cannonMode;
    private InputActionMap _cannonButton;

    SkinnedMeshRenderer _meshRenderer;

    bool cannonEntered = false;

    ISwapView _interfaceSwapView;

    private void Awake()
    {
        _actionAsset = this.GetComponent<PlayerInput>().actions;
        player = _actionAsset.FindActionMap("GameplayControls");

        //_input.GameplayControls.CannonControl.performed += ctx => _cannonButtonPressed = ctx.ReadValueAsButton();
        //_input.GameplayControls.CannonControl.canceled += ctx => _cannonButtonPressed = false;

        _cannonMode = _actionAsset.FindActionMap("CannonMode");
    }

    void Start()
    {
        _cinemachine = GetComponent<CinemachineCamera>();
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
            _interfaceSwapView.Interact();
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
            other.gameObject.GetComponent<CinemachineCamera>().enabled = true;
            _virtualCamera1.enabled = false;
            _charMovementScript.enabled = false;
            _emoteWheel.enabled = false;
            _meshRenderer.enabled = false;
            FreezeConstraints();
        }

        if (_cannonButtonPressed && _inCannonMode)
        {
            other.gameObject.GetComponent<CannonShoot>().enabled = false;
            other.gameObject.GetComponent<CinemachineCamera>().enabled = false;
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
            _virtualCamera1.Priority = new PrioritySettings { Enabled = true, Value = 0 };
            _virtualCamera2.Priority = new PrioritySettings { Enabled = true, Value = 1 };
        }
        else
        {
            _virtualCamera1.Priority = new PrioritySettings { Enabled = true, Value = 1 };
            _virtualCamera2.Priority = new PrioritySettings { Enabled = true, Value = 0 };
        }

        yield return new WaitForSeconds(1f);
    }

    public void Interact()
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
        player.Enable();
    }

    private void OnDisable()
    {
        player.Disable();
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
