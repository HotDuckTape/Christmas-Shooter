//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Player/PlayerInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""GameplayControls"",
            ""id"": ""69757c57-bf74-4d25-af12-a9a51fdf2e73"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d456be5a-01cc-4b5f-a17f-3383e0894978"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Running"",
                    ""type"": ""PassThrough"",
                    ""id"": ""afc8b41a-dc56-4086-b11f-4bfe3ce8d165"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Emotes"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7ba0859c-610d-4135-8d56-b396e9853bea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CannonControl"",
                    ""type"": ""PassThrough"",
                    ""id"": ""284ab1af-03c6-4165-babc-2872eea247ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PickupObjects"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f06551a8-8a5e-48e7-8d47-22fe7f436db4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CamMove"",
                    ""type"": ""PassThrough"",
                    ""id"": ""323147de-458e-4fb2-85ac-f738f7215a1a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""51f59afd-01f9-4a14-8fab-97778be0643d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""7413323e-bf12-4da0-8065-aa3587834485"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""675d0d30-18f5-4776-84b5-cd0c53fba00e"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Running"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1fc1c2f-0575-46ae-b108-c179533518d4"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Running"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""013cbc1e-2573-431f-9e7f-dbf2bb3c058b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""a12540b5-7ba8-4153-8335-160903d232fd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""10950501-5bf0-4d0f-94f7-4e405efcad10"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7afc6734-812a-4f7f-9172-9ac97f16f29f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8de82b32-7ba0-48af-8c12-ec6340f4f383"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6e750c60-b622-4772-9f96-9e0f998457bb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""72e6cf34-941b-4f20-bfc3-73d21f754aa2"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Emotes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f62a2de-9ee5-4ad0-8384-77f2b4e15c06"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Emotes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae5f428e-edcb-4a64-a52d-bb843d767324"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Emotes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a43b5ccd-0042-4875-ab51-09115871f962"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Emotes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68c998b3-c1ba-498b-97aa-14df2df863d5"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Emotes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1510f5d1-3312-41f9-9d15-5cb57f3f9692"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Emotes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f221c1e9-2daf-4ba2-b97f-09449304b704"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Emotes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81593480-6c61-457c-b2a8-00e77ee207d2"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Emotes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e97805f8-b0b9-41b7-b60b-f08a657c6ae8"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CannonControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00dfeb38-fc06-4fb5-9b84-8c1925c5d4e2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CannonControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f78ccfb-4b5a-42fd-9ec1-0b70822d5fff"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickupObjects"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dba66a19-70b4-4251-9536-a74b76ed7a75"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickupObjects"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""005b9368-7a90-4332-8d52-13cf1446219d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""457d1a67-aaa7-406f-b560-f0453e2c8157"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e771a6d0-b6b4-4408-96bf-549cad4e318a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""4cc81ed4-f7c1-4322-852e-c019ce620043"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""3eaa0fa3-f515-4508-b7d4-b4c6fbbfece1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3ac8baa5-0d74-428a-855e-603a4b41c335"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CannonMode"",
            ""id"": ""f220bfcb-a623-44a9-aba5-2e22e8bea04f"",
            ""actions"": [
                {
                    ""name"": ""Aiming"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c4972b05-c4de-4d75-bdca-de7245733d85"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""244de854-08fe-477d-addd-41055cf20586"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8eb8d4d3-d088-4a70-a5dc-02a4ef2aff8f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""96bbddd6-e561-4e08-9e69-58b4ad0d391b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2340f335-d59e-4d25-b012-55c294da258b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1610f58c-459b-4057-a11d-9a5dde09544d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e306b642-5c6a-4182-9a44-7a837ec2040f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""869acb3f-0139-483c-b750-1f8e568d17ac"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c04a1792-fee1-4df1-87f6-e31bbe386260"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f80d966-b0aa-457a-af5e-49de03d2e0bc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameplayControls
        m_GameplayControls = asset.FindActionMap("GameplayControls", throwIfNotFound: true);
        m_GameplayControls_Movement = m_GameplayControls.FindAction("Movement", throwIfNotFound: true);
        m_GameplayControls_Running = m_GameplayControls.FindAction("Running", throwIfNotFound: true);
        m_GameplayControls_Emotes = m_GameplayControls.FindAction("Emotes", throwIfNotFound: true);
        m_GameplayControls_CannonControl = m_GameplayControls.FindAction("CannonControl", throwIfNotFound: true);
        m_GameplayControls_PickupObjects = m_GameplayControls.FindAction("PickupObjects", throwIfNotFound: true);
        m_GameplayControls_CamMove = m_GameplayControls.FindAction("CamMove", throwIfNotFound: true);
        m_GameplayControls_Shoot = m_GameplayControls.FindAction("Shoot", throwIfNotFound: true);
        m_GameplayControls_Reload = m_GameplayControls.FindAction("Reload", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Newaction = m_UI.FindAction("New action", throwIfNotFound: true);
        // CannonMode
        m_CannonMode = asset.FindActionMap("CannonMode", throwIfNotFound: true);
        m_CannonMode_Aiming = m_CannonMode.FindAction("Aiming", throwIfNotFound: true);
        m_CannonMode_Shoot = m_CannonMode.FindAction("Shoot", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GameplayControls
    private readonly InputActionMap m_GameplayControls;
    private List<IGameplayControlsActions> m_GameplayControlsActionsCallbackInterfaces = new List<IGameplayControlsActions>();
    private readonly InputAction m_GameplayControls_Movement;
    private readonly InputAction m_GameplayControls_Running;
    private readonly InputAction m_GameplayControls_Emotes;
    private readonly InputAction m_GameplayControls_CannonControl;
    private readonly InputAction m_GameplayControls_PickupObjects;
    private readonly InputAction m_GameplayControls_CamMove;
    private readonly InputAction m_GameplayControls_Shoot;
    private readonly InputAction m_GameplayControls_Reload;
    public struct GameplayControlsActions
    {
        private @PlayerInputs m_Wrapper;
        public GameplayControlsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_GameplayControls_Movement;
        public InputAction @Running => m_Wrapper.m_GameplayControls_Running;
        public InputAction @Emotes => m_Wrapper.m_GameplayControls_Emotes;
        public InputAction @CannonControl => m_Wrapper.m_GameplayControls_CannonControl;
        public InputAction @PickupObjects => m_Wrapper.m_GameplayControls_PickupObjects;
        public InputAction @CamMove => m_Wrapper.m_GameplayControls_CamMove;
        public InputAction @Shoot => m_Wrapper.m_GameplayControls_Shoot;
        public InputAction @Reload => m_Wrapper.m_GameplayControls_Reload;
        public InputActionMap Get() { return m_Wrapper.m_GameplayControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayControlsActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayControlsActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Running.started += instance.OnRunning;
            @Running.performed += instance.OnRunning;
            @Running.canceled += instance.OnRunning;
            @Emotes.started += instance.OnEmotes;
            @Emotes.performed += instance.OnEmotes;
            @Emotes.canceled += instance.OnEmotes;
            @CannonControl.started += instance.OnCannonControl;
            @CannonControl.performed += instance.OnCannonControl;
            @CannonControl.canceled += instance.OnCannonControl;
            @PickupObjects.started += instance.OnPickupObjects;
            @PickupObjects.performed += instance.OnPickupObjects;
            @PickupObjects.canceled += instance.OnPickupObjects;
            @CamMove.started += instance.OnCamMove;
            @CamMove.performed += instance.OnCamMove;
            @CamMove.canceled += instance.OnCamMove;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @Reload.started += instance.OnReload;
            @Reload.performed += instance.OnReload;
            @Reload.canceled += instance.OnReload;
        }

        private void UnregisterCallbacks(IGameplayControlsActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Running.started -= instance.OnRunning;
            @Running.performed -= instance.OnRunning;
            @Running.canceled -= instance.OnRunning;
            @Emotes.started -= instance.OnEmotes;
            @Emotes.performed -= instance.OnEmotes;
            @Emotes.canceled -= instance.OnEmotes;
            @CannonControl.started -= instance.OnCannonControl;
            @CannonControl.performed -= instance.OnCannonControl;
            @CannonControl.canceled -= instance.OnCannonControl;
            @PickupObjects.started -= instance.OnPickupObjects;
            @PickupObjects.performed -= instance.OnPickupObjects;
            @PickupObjects.canceled -= instance.OnPickupObjects;
            @CamMove.started -= instance.OnCamMove;
            @CamMove.performed -= instance.OnCamMove;
            @CamMove.canceled -= instance.OnCamMove;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @Reload.started -= instance.OnReload;
            @Reload.performed -= instance.OnReload;
            @Reload.canceled -= instance.OnReload;
        }

        public void RemoveCallbacks(IGameplayControlsActions instance)
        {
            if (m_Wrapper.m_GameplayControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayControlsActions @GameplayControls => new GameplayControlsActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_Newaction;
    public struct UIActions
    {
        private @PlayerInputs m_Wrapper;
        public UIActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_UI_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);

    // CannonMode
    private readonly InputActionMap m_CannonMode;
    private List<ICannonModeActions> m_CannonModeActionsCallbackInterfaces = new List<ICannonModeActions>();
    private readonly InputAction m_CannonMode_Aiming;
    private readonly InputAction m_CannonMode_Shoot;
    public struct CannonModeActions
    {
        private @PlayerInputs m_Wrapper;
        public CannonModeActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aiming => m_Wrapper.m_CannonMode_Aiming;
        public InputAction @Shoot => m_Wrapper.m_CannonMode_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_CannonMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CannonModeActions set) { return set.Get(); }
        public void AddCallbacks(ICannonModeActions instance)
        {
            if (instance == null || m_Wrapper.m_CannonModeActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CannonModeActionsCallbackInterfaces.Add(instance);
            @Aiming.started += instance.OnAiming;
            @Aiming.performed += instance.OnAiming;
            @Aiming.canceled += instance.OnAiming;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(ICannonModeActions instance)
        {
            @Aiming.started -= instance.OnAiming;
            @Aiming.performed -= instance.OnAiming;
            @Aiming.canceled -= instance.OnAiming;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(ICannonModeActions instance)
        {
            if (m_Wrapper.m_CannonModeActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICannonModeActions instance)
        {
            foreach (var item in m_Wrapper.m_CannonModeActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CannonModeActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CannonModeActions @CannonMode => new CannonModeActions(this);
    public interface IGameplayControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRunning(InputAction.CallbackContext context);
        void OnEmotes(InputAction.CallbackContext context);
        void OnCannonControl(InputAction.CallbackContext context);
        void OnPickupObjects(InputAction.CallbackContext context);
        void OnCamMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface ICannonModeActions
    {
        void OnAiming(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
