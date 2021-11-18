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
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3a9b6ac9-d2c5-42ff-92bc-d29db7df0878"",
                    ""path"": ""2DVector"",
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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Accelerate
        m_Accelerate = asset.FindActionMap("Accelerate", throwIfNotFound: true);
        m_Accelerate_Move = m_Accelerate.FindAction("Move", throwIfNotFound: true);
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
    public struct AccelerateActions
    {
        private @AccelerateInput m_Wrapper;
        public AccelerateActions(@AccelerateInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Accelerate_Move;
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
            }
            m_Wrapper.m_AccelerateActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public AccelerateActions @Accelerate => new AccelerateActions(this);
    public interface IAccelerateActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
