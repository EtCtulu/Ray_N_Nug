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
    private Vector3 rbLocalForward;
    private Vector3 rbLocalUp;
    private Quaternion rbLocalRotation;
    public AccelerateInput instance;

    [Header("Parent du character")]
    [Space(10)]
    [Tooltip("Script utilisé pour déplacer le joueur sur l'axe Z, on y trouve sa vitesse.")]
    public CinemachineDollyCart playerParent;

    [Range(5, 100)]
    [Header("Vitesse sur l'axe Z")]
    [Space(10)]
    [Tooltip("Vitesse sans boost")]
    public float trailSpeed = 20;

    [Range(5, 100)]
    [Tooltip("Vitesse avec boost")]
    public float boostTrailSpeed = 50;

    [Range(5, 100)]
    [Tooltip("Vitesse avec frein")]
    public float slowTrailSpeed = 10;

    [Header("Vitesse sur l'axe X et Y")]
    [Space(10)]
    [Tooltip("Vitesse du boost")]
    [Range(0, 6)]
    public int strafeSpeedMultiply = 3;

    [Range(5, 30)]
    [Tooltip("Valeur de vitesse utilisé pour le déplacement en X et Y de Ray")]
    public float strafeSpeed = 20f;

    [Header("Cooldowns")]
    [Space(10)]
    [Range(0, 10)]
    [Tooltip("Cooldown du dash de côté")]
    public float sideDashCooldown = 1f;


    private float time = 0;

    // Valeures pour le déplacement des personnages.

    // Les inputs Normalisés
    public float NormInputX { get; private set; }
    public float NormInputY { get; private set; }

    // Les inputs non normalisés

    public float inputX { get; private set; }
    public float inputY { get; private set; }
    

    private bool isMoving = false;

    private bool isBoosting = false;

    private bool isSlowing = false;

    private bool isStopping = false;

    private bool isSpeeding = false;

    private bool isInvicible = false;

    private bool shotsDismissal = false;

    private bool canSideDash = false;

    private bool sideSecurity = false;

    //private Vector3 currentEulerAngles;
    //private Quaternion currentRotation; 
    

    private void Awake() 
    {
        aInput = new AccelerateInput();
        rbCharacter = transform.GetChild(0).GetComponent<Rigidbody>();
        rbCharacterTransform = rbCharacter.transform;
    }

    private void Update()
    {
        if(isBoosting)
        {
            time += Time.deltaTime;
            playerParent.m_Speed = Mathf.Lerp(trailSpeed, boostTrailSpeed, time);
        }
        if(isSlowing)
        {
            time += Time.deltaTime * 2;
            playerParent.m_Speed = Mathf.Lerp(boostTrailSpeed, trailSpeed, time);
            if(time >= 1)
            {
                isSlowing = false;
                isBoosting = false;
                time = 0;
            }
        }
        if(isStopping)
        {
            time += Time.deltaTime * 4;
            playerParent.m_Speed = Mathf.Lerp(trailSpeed, slowTrailSpeed, time);
        }
        if(isSpeeding)
        {
            time += Time.deltaTime * 2;
            playerParent.m_Speed = Mathf.Lerp(slowTrailSpeed, trailSpeed, time);
            if(time >= 1)
            {
                isStopping = false;
                isSpeeding = false;
                time = 0;
            }
        }
    }

    private void LateUpdate() 
    {
        if(!isMoving)
        {
            Debug.Log("Stop Move");
            //rbCharacterTransform.rotation = Quaternion.Slerp(rbCharacterTransform.localRotation, Quaternion.LookRotation(new Vector2(0,0), transform.up), Time.deltaTime * 4f);
        }      
    }

    // Fonction qui sert a donner le mouvement en X et Y de ray
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 rawMoveInput = context.ReadValue<Vector2>();
        //Debug.Log(rawMoveInput);
        //rbCharacter.velocity = rawMoveInput * strafeSpeed;
        isMoving = true;
 
        // Debug.Log(moveInput);
        rbCharacter.velocity = transform.TransformDirection(rawMoveInput * strafeSpeed);
        
        rbCharacterTransform.localRotation = Quaternion.Slerp(Quaternion.LookRotation(transform.forward, transform.up), 
        Quaternion.LookRotation(rawMoveInput, rbCharacterTransform.InverseTransformDirection(rbCharacterTransform.up)), .4f);  

        /*currentEulerAngles += new Vector3(rawMoveInput.x, rawMoveInput.y, 0) * 45 * Time.deltaTime;

        currentRotation.eulerAngles = currentEulerAngles;

        rbCharacterTransform.rotation*/

        
        if (context.ReadValue<Vector2>() == new Vector2(0,0))
        {
            isMoving = false;
        }
    }


    // Fonction qui sert a augmenter la vitesse sur l'axe Z
    public void Accelerate(InputAction.CallbackContext context)
    {
        Debug.Log("Ohlala on va vite");
        if(context.performed && !isBoosting)
        {
            isBoosting = true;
        }
        else if(context.canceled && isBoosting)
        {
            Debug.Log("Retour a la normale");
            time = 0;
            isBoosting = false;
            isSlowing = true;            
            // playerParent.m_Speed = trailSpeed;
        }
    }

    // Fonction qui sert a baisser la vitesse sur l'axe Z
    public void SlowDown(InputAction.CallbackContext context)
    {
        if(!isBoosting)
        {
        if(context.performed && !isStopping)
        {
            Debug.Log("Ohlala on va lentement");
            isStopping = true;
            // playerParent.m_Speed = slowTrailSpeed;
        }
        else if(context.canceled && isStopping)
        {
            Debug.Log("ON EST PLUS LENT");
            time = 0;
            isStopping = false;
            isSpeeding = true;
        }
        }
    }


    #region Strafe

    public void Strafe(InputAction.CallbackContext context)
    {
        if(context.performed){
        if(sideSecurity)
        {
            Debug.Log("Non");
            return;
        }
        if(canSideDash)
        {
            Debug.Log("SideDASH SPEEEEED");
            strafeSpeed = strafeSpeed * strafeSpeedMultiply;
            sideSecurity = true;
            Invoke("ResetSpeed", 0.2f);
            return;
        }
        Debug.Log("Initial Strafe");
        isInvicible = true;
        shotsDismissal = true;
        canSideDash = true;
        Invoke("DeactivateDismissal", 0.2f);
        Invoke("DeactivateSideDash", 0.25f);
        Invoke("DeactivateInvicible", 1f);
        Invoke("CooldownSideDash", sideDashCooldown);
        }
    }

    public void DeactivateDismissal()
    {
        shotsDismissal = false;
    }

    public void DeactivateInvicible()
    {
        isInvicible = false;
        
    }

    public void DeactivateSideDash()
    {
        canSideDash = false;
    }

    public void ResetSpeed()
    {
        strafeSpeed = strafeSpeed / strafeSpeedMultiply;
    }
    
    public void CooldownSideDash()
    {
        sideSecurity = false;
    }

    #endregion


}
