// GENERATED AUTOMATICALLY FROM 'Assets/SampleSceneAssets/TutorialInfo/Scripts/Diorama/DioramaCamera.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DioramaCamera : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DioramaCamera()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DioramaCamera"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""7acd06c8-d353-4d5f-9072-717408d3b6c5"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""fc6e2f9f-8b04-48ed-a96d-f02ea2674efd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Backward"",
                    ""type"": ""Button"",
                    ""id"": ""3aaa9142-b28d-4a76-a661-0019b6218e52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""1cdcc1e5-9b69-4ccc-bb38-84a909605055"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""f4dbdf38-231b-451b-ab1d-ea150707ce61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""6234f304-7dab-452b-9bef-deb03aa4cf5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""6440ef02-a524-4ee5-adae-1985236c8900"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CursorLock"",
                    ""type"": ""Button"",
                    ""id"": ""4e1221a1-989c-4481-93aa-a934049b524e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CursorUnlock"",
                    ""type"": ""Button"",
                    ""id"": ""affceb2b-d576-4884-99ae-444d75cbd835"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""007828fa-6d73-4883-8fe4-f1c2504d747d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""09f46ffe-bab3-4e8f-b7b4-746f616de678"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GamepadLook"",
                    ""type"": ""Value"",
                    ""id"": ""4b987b4d-526c-41df-9b26-cffaec4f792a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8438f543-1f40-46d8-ba58-8b5149d58774"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de5475a6-4946-4ce4-9642-38c6487fd032"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbf13540-7b49-4e0f-81fa-2d6c8ac341ed"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c135345-a180-48ae-95bb-4396f683c276"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04bcc4ae-8bb4-4b4a-a3d8-fa0240e10b21"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8af9ca14-28c2-4440-8371-1d79cf436d07"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ea4eb23-02f1-4c58-950a-ae987ead4c47"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0279eb5a-47e9-40ab-a0b1-ff95e6fdf931"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d3ca80e-0bc2-41f8-b54d-517eefc0feca"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CursorLock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33e11b7b-e563-441e-90aa-769ae09fb8f6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CursorUnlock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""566783d5-9a36-4d6b-b929-977933c7831d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f514cadb-e56f-44b0-b28c-c0f1c9d64d0b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GamepadLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Forward = m_Camera.FindAction("Forward", throwIfNotFound: true);
        m_Camera_Backward = m_Camera.FindAction("Backward", throwIfNotFound: true);
        m_Camera_Left = m_Camera.FindAction("Left", throwIfNotFound: true);
        m_Camera_Right = m_Camera.FindAction("Right", throwIfNotFound: true);
        m_Camera_Up = m_Camera.FindAction("Up", throwIfNotFound: true);
        m_Camera_Down = m_Camera.FindAction("Down", throwIfNotFound: true);
        m_Camera_CursorLock = m_Camera.FindAction("CursorLock", throwIfNotFound: true);
        m_Camera_CursorUnlock = m_Camera.FindAction("CursorUnlock", throwIfNotFound: true);
        m_Camera_MousePosition = m_Camera.FindAction("MousePosition", throwIfNotFound: true);
        m_Camera_Move = m_Camera.FindAction("Move", throwIfNotFound: true);
        m_Camera_GamepadLook = m_Camera.FindAction("GamepadLook", throwIfNotFound: true);
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

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_Forward;
    private readonly InputAction m_Camera_Backward;
    private readonly InputAction m_Camera_Left;
    private readonly InputAction m_Camera_Right;
    private readonly InputAction m_Camera_Up;
    private readonly InputAction m_Camera_Down;
    private readonly InputAction m_Camera_CursorLock;
    private readonly InputAction m_Camera_CursorUnlock;
    private readonly InputAction m_Camera_MousePosition;
    private readonly InputAction m_Camera_Move;
    private readonly InputAction m_Camera_GamepadLook;
    public struct CameraActions
    {
        private @DioramaCamera m_Wrapper;
        public CameraActions(@DioramaCamera wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Camera_Forward;
        public InputAction @Backward => m_Wrapper.m_Camera_Backward;
        public InputAction @Left => m_Wrapper.m_Camera_Left;
        public InputAction @Right => m_Wrapper.m_Camera_Right;
        public InputAction @Up => m_Wrapper.m_Camera_Up;
        public InputAction @Down => m_Wrapper.m_Camera_Down;
        public InputAction @CursorLock => m_Wrapper.m_Camera_CursorLock;
        public InputAction @CursorUnlock => m_Wrapper.m_Camera_CursorUnlock;
        public InputAction @MousePosition => m_Wrapper.m_Camera_MousePosition;
        public InputAction @Move => m_Wrapper.m_Camera_Move;
        public InputAction @GamepadLook => m_Wrapper.m_Camera_GamepadLook;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnForward;
                @Backward.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnBackward;
                @Backward.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnBackward;
                @Backward.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnBackward;
                @Left.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnRight;
                @Up.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnDown;
                @CursorLock.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnCursorLock;
                @CursorLock.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnCursorLock;
                @CursorLock.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnCursorLock;
                @CursorUnlock.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnCursorUnlock;
                @CursorUnlock.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnCursorUnlock;
                @CursorUnlock.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnCursorUnlock;
                @MousePosition.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMousePosition;
                @Move.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
                @GamepadLook.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnGamepadLook;
                @GamepadLook.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnGamepadLook;
                @GamepadLook.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnGamepadLook;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Backward.started += instance.OnBackward;
                @Backward.performed += instance.OnBackward;
                @Backward.canceled += instance.OnBackward;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @CursorLock.started += instance.OnCursorLock;
                @CursorLock.performed += instance.OnCursorLock;
                @CursorLock.canceled += instance.OnCursorLock;
                @CursorUnlock.started += instance.OnCursorUnlock;
                @CursorUnlock.performed += instance.OnCursorUnlock;
                @CursorUnlock.canceled += instance.OnCursorUnlock;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @GamepadLook.started += instance.OnGamepadLook;
                @GamepadLook.performed += instance.OnGamepadLook;
                @GamepadLook.canceled += instance.OnGamepadLook;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);
    public interface ICameraActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnBackward(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnCursorLock(InputAction.CallbackContext context);
        void OnCursorUnlock(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnGamepadLook(InputAction.CallbackContext context);
    }
}
