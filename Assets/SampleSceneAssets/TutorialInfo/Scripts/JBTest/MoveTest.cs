using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTest : MonoBehaviour
{
    public AccelerateInput aInput;
    private Rigidbody rb;
    public AccelerateInput instance;
    public float speed = 20f;

    public Vector2 rightStick;


    private void Awake() 
    {
        aInput = new AccelerateInput();
        rb = GetComponent<Rigidbody>();
        aInput.Accelerate.Move.performed += ctx => rightStick = ctx.ReadValue<Vector2>();
        aInput.Accelerate.Move.canceled += ctx => rightStick = Vector2.zero;
    }

    void FixedUpdate() 
    {
        
        
    }

    public void Accelerate(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        Debug.Log(rightStick);
        rb.velocity = moveInput * speed;
    }

}
