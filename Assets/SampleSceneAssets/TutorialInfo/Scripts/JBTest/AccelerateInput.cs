// GENERATED AUTOMATICALLY FROM 'Assets/SampleSceneAssets/TutorialInfo/Scripts/JBTest/AccelerateInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @AccelerateInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @AccelerateInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""AccelerateInput"",
    ""maps"": [
        {
            ""name"": ""Accelerate"",
            ""id"": ""8373dce1-1ae2-431c-b666-bf02714cde37"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""90a7786f-87b5-487c-81ea-65856d4d3d00"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""3a6ffc52-7889-4488-95cc-6617c529a384"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SlowDown"",
                    ""type"": ""Button"",
                    ""id"": ""a68aafaa-4692-418b-a3a0-048bd7f7230a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""26e7f9ef-4162-428c-95df-bc14892c5e28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3a9b6ac9-d2c5-42ff-92bc-d29db7df0878"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b3cfbe41-ceb5-47a4-9f93-a8416d1555ec"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b27c3d40-a91c-4d4e-a742-6630bf09dd4e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""58a47caf-b3f4-4053-a244-60fd4fdb1dc1"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b15dc777-0a52-4058-98f4-992667ebffda"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c4f0e4a5-f435-43bf-89f2-89e9a83b78eb"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f6b2a64-5736-4832-b3ad-25911b9ec5ac"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlowDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44fb97eb-4ae4-4677-9827-36e92ff3a5b1"",
                    ""path"": ""<Gamepad>/rightShoulder"",
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
        // Accelerate
        m_Accelerate = asset.FindActionMap("Accelerate", throwIfNotFound: true);
        m_Accelerate_Move = m_Accelerate.FindAction("Move", throwIfNotFound: true);
        m_Accelerate_Accelerate = m_Accelerate.FindAction("Accelerate", throwIfNotFound: true);
        m_Accelerate_SlowDown = m_Accelerate.FindAction("SlowDown", throwIfNotFound: true);
        m_Accelerate_Shoot = m_Accelerate.FindAction("Shoot", throwIfNotFound: true);
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

    // Accelerate
    private readonly InputActionMap m_Accelerate;
    private IAccelerateActions m_AccelerateActionsCallbackInterface;
    private readonly InputAction m_Accelerate_Move;
    private readonly InputAction m_Accelerate_Accelerate;
    private readonly InputAction m_Accelerate_SlowDown;
    private readonly InputAction m_Accelerate_Shoot;
    public struct AccelerateActions
    {
        private @AccelerateInput m_Wrapper;
        public AccelerateActions(@AccelerateInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Accelerate_Move;
        public InputAction @Accelerate => m_Wrapper.m_Accelerate_Accelerate;
        public InputAction @SlowDown => m_Wrapper.m_Accelerate_SlowDown;
        public InputAction @Shoot => m_Wrapper.m_Accelerate_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Accelerate; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AccelerateActions set) { return set.Get(); }
        public void SetCallbacks(IAccelerateActions instance)
        {
            if (m_Wrapper.m_AccelerateActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_AccelerateActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_AccelerateActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_AccelerateActionsCallbackInterface.OnMove;
                @Accelerate.started -= m_Wrapper.m_AccelerateActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_AccelerateActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_AccelerateActionsCallbackInterface.OnAccelerate;
                @SlowDown.started -= m_Wrapper.m_AccelerateActionsCallbackInterface.OnSlowDown;
                @SlowDown.performed -= m_Wrapper.m_AccelerateActionsCallbackInterface.OnSlowDown;
                @SlowDown.canceled -= m_Wrapper.m_AccelerateActionsCallbackInterface.OnSlowDown;
                @Shoot.started -= m_Wrapper.m_AccelerateActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_AccelerateActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_AccelerateActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_AccelerateActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @SlowDown.started += instance.OnSlowDown;
                @SlowDown.performed += instance.OnSlowDown;
                @SlowDown.canceled += instance.OnSlowDown;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public AccelerateActions @Accelerate => new AccelerateActions(this);
    public interface IAccelerateActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAccelerate(InputAction.CallbackContext context);
        void OnSlowDown(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
