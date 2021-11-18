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


    private void Awake() 
    {
        aInput = new AccelerateInput();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        
        
    }

    public void Accelerate()
    {
        Vector2 moveInput = aInput.Accelerate.Move.ReadValue<Vector2>();
        Debug.Log(moveInput);
        rb.velocity = moveInput * speed;
    }

}
