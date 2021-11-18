using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTest : MonoBehaviour
{

    // Déclarations des variables utiles
    public AccelerateInput aInput;
    private Rigidbody rb;
    public AccelerateInput instance;

    // Valeures pour le déplacement des personnages.
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public float strafeSpeed = 20f;


    private void Awake() 
    {
        aInput = new AccelerateInput();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 rawMoveInput = context.ReadValue<Vector2>();
        Debug.Log(rawMoveInput);
        rb.velocity = rawMoveInput * strafeSpeed;
        if (Mathf.Abs(rawMoveInput.x) > 0.5f)
        {
            NormInputX = (int)(rawMoveInput * Vector2.right).normalized.x;
        }
        else
        {
            NormInputX = 0;
        }

        if (Mathf.Abs(rawMoveInput.y) > 0.5f)
        {
            NormInputY = (int)(rawMoveInput * Vector2.up).normalized.y;
        }
        else
        {
            NormInputY = 0;
        }
        Vector2 moveInput = new Vector2(NormInputX,NormInputY);
        rb.velocity = moveInput * strafeSpeed;
    }

    public void Accelerate(InputAction.CallbackContext context)
    {
        Debug.Log("Ohlala on va vite");
    }

    public void SlowDown(InputAction.CallbackContext context)
    {
        Debug.Log("Ohlala on ralentit");
    }

}
