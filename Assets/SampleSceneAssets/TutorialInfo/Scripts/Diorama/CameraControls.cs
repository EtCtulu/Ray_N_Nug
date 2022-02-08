using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{
     #region UI

    [Space]

    [SerializeField]
    [Tooltip("The script is currently active")]
    private bool _active = true;

    [Space]

    [SerializeField]
    [Tooltip("Camera rotation by mouse movement is active")]
    private bool _enableRotation = true;

    [SerializeField]
    [Tooltip("Sensitivity of mouse rotation")]
    private float _mouseSense = 1.8f;

    [Space]

    [SerializeField]
    [Tooltip("Camera zooming in/out by 'Mouse Scroll Wheel' is active")]
    private bool _enableTranslation = true;

    [SerializeField]
    [Tooltip("Velocity of camera zooming in/out")]
    private float _translationSpeed = 55f;

    [Space]

    [SerializeField]
    [Tooltip("Camera movement by 'W','A','S','D','Q','E' keys is active")]
    private bool _enableMovement = true;

    [SerializeField]
    [Tooltip("Camera movement speed")]
    private float _movementSpeed = 10f;

    [SerializeField]
    [Tooltip("Acceleration at camera movement is active")]
    private bool _enableSpeedAcceleration = true;

    [SerializeField]
    [Tooltip("Rate which is applied during camera movement")]
    private float _speedAccelerationFactor = 1.5f;

    #endregion UI

    private Vector3 deltaPosition = Vector3.zero;
    private float currentSpeed;

    private CursorLockMode _wantedMode;

    private float _currentIncrease = 1;
    private float _currentIncreaseMem = 0;

    private Vector3 _initPosition;
    private Vector3 _initRotation;

    private float mouseX;
    private float mouseY;

    private void OnEnable()
    {
        if (_active)
            _wantedMode = CursorLockMode.Locked;
    }

    private void Awake() 
    {
        currentSpeed = _movementSpeed;
    }

    private void Start() 
    {
        _initPosition = transform.position;
        _initRotation = transform.eulerAngles;
    }

    private void SetCursorState()
    {
        
        Cursor.lockState = _wantedMode;
        Cursor.visible = (CursorLockMode.Locked != _wantedMode);
    }

    private void CalculateCurrentIncrease(bool moving)
    {
        _currentIncrease = Time.deltaTime;

        if (!_enableSpeedAcceleration || _enableSpeedAcceleration && !moving)
        {
            _currentIncreaseMem = 0;
            return;
        }

        _currentIncreaseMem += Time.deltaTime * (_speedAccelerationFactor - 1);
        _currentIncrease = Time.deltaTime + Mathf.Pow(_currentIncreaseMem, 3) * Time.deltaTime;
    }

    private void Update()
    {
        if (!_active)
            return;

        SetCursorState();

        if (Cursor.visible)
            return;

        // Translation
        if (_enableTranslation)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _translationSpeed);
        }

        // Movement
        if (_enableMovement)
        {
            Vector3 deltaPosition = Vector3.zero;
            float currentSpeed = _movementSpeed;

            // Calc acceleration
            CalculateCurrentIncrease(deltaPosition != Vector3.zero);

            transform.position += deltaPosition * currentSpeed * _currentIncrease;
        }

        // Rotation
        if (_enableRotation)
        {
            // Pitch
            transform.rotation *= Quaternion.AngleAxis(-mouseY* _mouseSense, Vector3.right);

            // Paw
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + mouseX * _mouseSense, transform.eulerAngles.z);
        }
    }

    public void GetMouseValue(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            mouseX = context.ReadValue<Vector2>().x;
            mouseY = context.ReadValue<Vector2>().y;
        }

    }

    public void MoveForward(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            deltaPosition += transform.forward;
        }
    }

    public void MoveBackwards(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            deltaPosition -= transform.forward;
        }
    }

    public void MoveRight(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            deltaPosition += transform.right;
        }
    }
    
    public void MoveLeft(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            deltaPosition -= transform.right;
        }
    }

    public void MoveUpwards(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            deltaPosition += transform.up;
        }
    }

    public void MoveDownwards(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            deltaPosition -= transform.up;
        }
    }

    public void ExitLockCursor(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Cursor.lockState = _wantedMode = CursorLockMode.None;
        }
    }
    
    public void LockCursor(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _wantedMode = CursorLockMode.Locked;
        }
    }
}


