using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTest : MonoBehaviour
{
    public AccelerateInput aInput;
    public Rigidbody rb;
    public float speed = 20f;

    
    void FixedUpdate() 
    {
        Vector2 moveInput = aInput.Accelerate.Move.ReadValue<Vector2>();
        rb.velocity = moveInput * speed;
    }

}
