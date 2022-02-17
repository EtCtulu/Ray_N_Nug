// GENERATED AUTOMATICALLY FROM 'Assets/SampleSceneAssets/TutorialInfo/Scripts/ReturnDiorama.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ReturnDiorama : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ReturnDiorama()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ReturnDiorama"",
    ""maps"": [
        {
            ""name"": ""return"",
            ""id"": ""88a498bf-850b-4702-b366-26415ef112d3"",
            ""actions"": [
                {
                    ""name"": ""Return scene 1"",
                    ""type"": ""Button"",
                    ""id"": ""f31d2cec-5730-4373-b5e7-7d0c0299eb55"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0a36ca24-e154-4123-88cd-65fddcb8c7f8"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Return scene 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // return
        m_return = asset.FindActionMap("return", throwIfNotFound: true);
        m_return_Returnscene1 = m_return.FindAction("Return scene 1", throwIfNotFound: true);
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

    // return
    private readonly InputActionMap m_return;
    private IReturnActions m_ReturnActionsCallbackInterface;
    private readonly InputAction m_return_Returnscene1;
    public struct ReturnActions
    {
        private @ReturnDiorama m_Wrapper;
        public ReturnActions(@ReturnDiorama wrapper) { m_Wrapper = wrapper; }
        public InputAction @Returnscene1 => m_Wrapper.m_return_Returnscene1;
        public InputActionMap Get() { return m_Wrapper.m_return; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ReturnActions set) { return set.Get(); }
        public void SetCallbacks(IReturnActions instance)
        {
            if (m_Wrapper.m_ReturnActionsCallbackInterface != null)
            {
                @Returnscene1.started -= m_Wrapper.m_ReturnActionsCallbackInterface.OnReturnscene1;
                @Returnscene1.performed -= m_Wrapper.m_ReturnActionsCallbackInterface.OnReturnscene1;
                @Returnscene1.canceled -= m_Wrapper.m_ReturnActionsCallbackInterface.OnReturnscene1;
            }
            m_Wrapper.m_ReturnActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Returnscene1.started += instance.OnReturnscene1;
                @Returnscene1.performed += instance.OnReturnscene1;
                @Returnscene1.canceled += instance.OnReturnscene1;
            }
        }
    }
    public ReturnActions @return => new ReturnActions(this);
    public interface IReturnActions
    {
        void OnReturnscene1(InputAction.CallbackContext context);
    }
}
