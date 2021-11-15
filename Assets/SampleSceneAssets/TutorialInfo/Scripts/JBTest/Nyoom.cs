// GENERATED AUTOMATICALLY FROM 'Assets/SampleSceneAssets/TutorialInfo/Scripts/JBTest/Nyoom.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Nyoom : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Nyoom()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Nyoom"",
    ""maps"": [
        {
            ""name"": ""Vroom"",
            ""id"": ""8373dce1-1ae2-431c-b666-bf02714cde37"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Value"",
                    ""id"": ""90a7786f-87b5-487c-81ea-65856d4d3d00"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5418dc2b-8669-4157-9d91-88b8b285cab5"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Vroom
        m_Vroom = asset.FindActionMap("Vroom", throwIfNotFound: true);
        m_Vroom_Newaction = m_Vroom.FindAction("New action", throwIfNotFound: true);
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

    // Vroom
    private readonly InputActionMap m_Vroom;
    private IVroomActions m_VroomActionsCallbackInterface;
    private readonly InputAction m_Vroom_Newaction;
    public struct VroomActions
    {
        private @Nyoom m_Wrapper;
        public VroomActions(@Nyoom wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Vroom_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Vroom; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VroomActions set) { return set.Get(); }
        public void SetCallbacks(IVroomActions instance)
        {
            if (m_Wrapper.m_VroomActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_VroomActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_VroomActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_VroomActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_VroomActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public VroomActions @Vroom => new VroomActions(this);
    public interface IVroomActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
