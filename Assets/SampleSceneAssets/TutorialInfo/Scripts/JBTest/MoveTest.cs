using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class MoveTest : MonoBehaviour
{

    // Déclarations des variables utiles
    public AccelerateInput aInput;
    private Rigidbody rbCharacter;

    private Transform rbCharacterTransform;
    public AccelerateInput instance;

    [Header("Parent du character")]
    [Space(10)]
    [Tooltip("Script utilisé pour déplacer le joueur sur l'axe Z, on y trouve sa vitesse.")]
    public CinemachineDollyCart playerParent;

    [Header("Vitesse sur l'axe Z")]
    [Space(10)]
    [Tooltip("Vitesse sans boost")]
    public float trailSpeed = 20;

    [Tooltip("Vitesse avec boost")]
    public float boostTrailSpeed = 50;

    [Tooltip("Vitesse avec frein")]
    public float slowTrailSpeed = 10;

    // Valeures pour le déplacement des personnages.

    // Les inputs Normalisés
    public float NormInputX { get; private set; }
    public float NormInputY { get; private set; }

    // Les inputs non normalisés

    public float inputX { get; private set; }
    public float inputY { get; private set; }


    [Header("Valeur de vitesse de côté")]
    [Space(10)]
    [Tooltip("Valeur de vitesse utilisé pour le déplacement en X et Y de Ray")]
    public float strafeSpeed = 20f;

    private bool isMoving = false;
    


    private void Awake() 
    {
        aInput = new AccelerateInput();
        rbCharacter = transform.GetChild(0).GetComponent<Rigidbody>();
        rbCharacterTransform = rbCharacter.transform;
    }



    private void LateUpdate() 
    {
        if(!isMoving)
        {
            Debug.Log("Stop Move");
            rbCharacterTransform.rotation = Quaternion.Slerp(rbCharacterTransform.rotation, Quaternion.LookRotation(new Vector2(0,0), transform.up), Time.deltaTime * 4f);
        }      
    }

    // Fonction qui sert a donner le mouvement en X et Y de ray
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 rawMoveInput = context.ReadValue<Vector2>();
        //Debug.Log(rawMoveInput);
        rbCharacter.velocity = rawMoveInput * strafeSpeed;
        isMoving = true;
        if (Mathf.Abs(rawMoveInput.x) > 0.1f)
        {
            inputX = (rawMoveInput * Vector2.right).x;
            NormInputX = (rawMoveInput * Vector2.right).normalized.x;
        }
        else
        {
            inputX = 0;
            NormInputX = 0;
        }

        if (Mathf.Abs(rawMoveInput.y) > 0.1f)
        {
            inputY = (rawMoveInput * Vector2.up).y;
            NormInputY = (rawMoveInput * Vector2.up).normalized.y;
        }
        else
        {
            inputY = 0;
            NormInputX = 0;
        }
        Vector2 moveInput = new Vector2(inputX, inputY);

        Vector3 vRotation = new Vector3(NormInputX, NormInputY, 0);
        
        Debug.Log(moveInput);
        rbCharacter.velocity = moveInput * strafeSpeed;

        rbCharacterTransform.rotation = Quaternion.Slerp(Quaternion.LookRotation(new Vector2(0,0), transform.up), Quaternion.LookRotation(vRotation, transform.up), Time.deltaTime * 5f);

        if (context.ReadValue<Vector2>() == new Vector2(0,0))
        {
            isMoving = false;
        }
    }


    // Fonction qui sert a augmenter la vitesse sur l'axe Z
    public void Accelerate(InputAction.CallbackContext context)
    {
        Debug.Log("Ohlala on va vite");
        if(context.performed)
        {
           playerParent.m_Speed = Mathf.Lerp(trailSpeed, boostTrailSpeed, Time.deltaTime);
        }
        else
        {
            playerParent.m_Speed = trailSpeed;
        }
    }

    // Fonction qui sert a baisser la vitesse sur l'axe Z
    public void SlowDown(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            playerParent.m_Speed = slowTrailSpeed;
        }
        else
        {
            playerParent.m_Speed = trailSpeed;
        }
    }

}
