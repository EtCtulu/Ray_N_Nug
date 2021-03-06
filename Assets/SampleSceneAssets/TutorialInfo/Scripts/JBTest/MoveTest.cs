using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class MoveTest : MonoBehaviour
{
    #region Usefull Variables To Setup

    // Déclarations des variables utiles
    public AccelerateInput aInput;
    private Rigidbody rbCharacter;

    private Transform rbCharacterTransform;
    private Vector3 rbLocalForward;
    private Vector3 rbLocalUp;

    private Quaternion rbLocalRotation;
    public AccelerateInput instance;
    public PlayerStats playerStats;

    

    [Header("Parent du character")]
    [Space(10)]
    [Tooltip("Script utilisé pour déplacer le joueur sur l'axe Z, on y trouve sa vitesse.")]
    public CinemachineDollyCart playerParent;

    #endregion

    #region Trail Variables

    [Range(5, 100)]
    [Header("Vitesse sur l'axe Z")]
    [Space(10)]
    [Tooltip("Vitesse sans boost")]
    public float trailSpeed = 20;

    [Range(5, 100)]
    [Tooltip("Vitesse avec boost")]
    public float boostTrailSpeed = 50;

    [Range(5, 100)]
    [Tooltip("Vitesse avec boost")]
    public float megaBoostTrailSpeed = 100;

    private float actualBoostSpeed;

    [Range(5, 100)]
    [Tooltip("Vitesse avec frein")]
    public float slowTrailSpeed = 10;

    [Header("Vitesse de drain du boost")]
    [Space(10)]
    [Tooltip("Vitesse de drain du systeme de boost")]
    public int boostbarDrainSpeed;

    #endregion

    #region Side Dash Variables

    [Header("Vitesse sur l'axe X et Y")]
    [Space(10)]
    [Tooltip("Vitesse du boost")]
    [Range(0, 6)]
    public int strafeSpeedMultiply = 3;

    [Range(5, 30)]
    [Tooltip("Valeur de vitesse utilisé pour le déplacement en X et Y de Ray")]
    public float strafeSpeed = 20f;

    #endregion

    #region Rotation and Quaternions

    [Range(0, 90)]
    [Tooltip("L'angle de rotation du character lorsqu'il se déplace sur les axes X et Y")]
    public int rotationAngle = 45;

    #endregion

    #region  Cooldowns

    #region Side Dash Cooldowns

    [Header("Cooldowns")]
    [Space(10)]
    [Range(0, 10)]
    [Tooltip("Cooldown du dash de côté")]
    public float sideDashCooldown = 1f;

    #endregion

    #region Boost Cooldowns

    [Space(10)]
    [Range(0, 10)]
    [Tooltip("Cooldown du Mega Boost")]
    public float megaBoostCooldown = 4f;

    public float megaBoostDuration = 3;

    #endregion

    #endregion

    #region Durations

    #region Side Dash Durations

    [Header("Durations")]
    [Space(10)]
    [Range(0,3)]
    [Tooltip("Durée du renvoi de tirs")]
    public float dismissalDuration = 0.2f;

    [Range(0,3)]
    [Tooltip("Durée de la fenetre pour faire un boost de côté")]
    public float sideBoostWindowDuration = 0.2f;

    [Range(0,3)]
    [Tooltip("Durée de l'insensibilité aux tirs ennemis")]
    public float dashInvicibilityDuration = 1f;

    [Range(0,3)]
    [Tooltip("Le temps que le boost de vitesse dure")]
    public float sideBoostDuration = 2f;

    #endregion

    #endregion

    #region Multipurpose Timer

    private float time = 0;

    #endregion

    #region Move Variables

    // Valeures pour le déplacement des personnages.

    // Les inputs Normalisés
    public float NormInputX { get; private set; }
    public float NormInputY { get; private set; }

    // Les inputs non normalisés

    public float inputX { get; private set; }
    public float inputY { get; private set; }

    #endregion
    
    #region Boost Variables

    private bool isMoving = false;

    [HideInInspector]
    public bool canMove = true;

    [HideInInspector]
    public bool canControl = true;

    private bool isBoosting = false;

    private bool isSlowing = false;

    private bool isStopping = false;

    private bool isSpeeding = false;

    private bool isMegaBoosting = false;

    private bool megaBoostSecurity = false;

    private bool touchedByEnemy;

    private bool megaBoostExtend = false;
    

    #endregion

    #region Side Dash Variables

    private bool isInvicible = false;

    private bool shotsDismissal = false;

    private bool canSideDash = false;

    private bool sideSecurity = false;

    #endregion

    #region Barrel Roll Variables

    private GameObject BarrelHBox;

    private bool canBRoll = true;

    [Header("Tonneau")]
    [Range(0,3)]
    [Tooltip("La durée pendant laquelle le joueur effectue son tonneau")]
    public float barrelRollDuration = 1f;

    [Range(0,3)]
    [Tooltip("La durée pendant laquelle le joueur ne peut plus effectuer de tonneaux")]
    public float barrelRollCD = 0.5f;

    #endregion
    
    #region Awake
    public static MoveTest Instance;

    private void Awake() 
    {
        #region Singleton
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        #endregion
        #region Variables Assign

        aInput = new AccelerateInput();
        rbCharacter = transform.GetChild(0).GetComponent<Rigidbody>();
        BarrelHBox = rbCharacter.transform.GetChild(1).gameObject;
        rbCharacterTransform = rbCharacter.transform;
        actualBoostSpeed = boostTrailSpeed;

        #endregion
    }
    #endregion

    private void Update()
    {
        if(shotsDismissal && isBoosting && megaBoostSecurity && touchedByEnemy && !megaBoostExtend)
        {
            megaBoostExtend = true;
        }
        if(shotsDismissal && isBoosting && !megaBoostSecurity && touchedByEnemy)
        {
            actualBoostSpeed = megaBoostTrailSpeed;
            megaBoostSecurity = true;
            Invoke("DeactivateOverBoost", megaBoostDuration);
            // Invoke("CooldownSideDash", sideDashCooldown);
        }

        #region Speed Modifiers In Update

        if(isBoosting == true && playerStats.playerBoost != 0)
        {
            time += Time.deltaTime;
            playerParent.m_Speed = Mathf.Lerp(trailSpeed, actualBoostSpeed, time);
            if(!isMegaBoosting)
            {
                playerStats.playerBoost -= Time.deltaTime * boostbarDrainSpeed;
                playerStats.playerBoost = Mathf.Clamp(playerStats.playerBoost, 0, 100);
                Debug.Log(playerStats.playerBoost);
            }

        }
        if(isSlowing)
        {
            time += Time.deltaTime * 2;
            playerParent.m_Speed = Mathf.Lerp(actualBoostSpeed, trailSpeed, time);
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

    #endregion

    }

    #region Side Move

    // Fonction qui sert a donner le mouvement en X et Y de ray
    public void Move(InputAction.CallbackContext context)
    {
        if(canMove && canControl)
        {
            Vector2 rawMoveInput = context.ReadValue<Vector2>();

            rbCharacter.velocity = transform.TransformDirection(rawMoveInput * strafeSpeed);
            
            rbCharacterTransform.localRotation = Quaternion.Euler(-rawMoveInput.y * rotationAngle, rawMoveInput.x * rotationAngle, 0f);

            isMoving = true;
            if(context.canceled)
            {
                isMoving = false;
            }
        }

        //rbCharacterTransform.localRotation = Quaternion.Slerp(rbCharacterTransform.localRotation, Quaternion.Euler(-rawMoveInput.y * rotationAngle, rawMoveInput.x * rotationAngle, 0f), .1f);
    }

    #endregion

    #region Speed Modifiers

    // Fonction qui sert a augmenter la vitesse sur l'axe Z
    public void Accelerate(InputAction.CallbackContext context)
    {
        if(canMove)
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
    }

    //Ancienne fonction de décélération
    /*
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
    */

    #endregion

    #region Strafe

    public void Strafe(InputAction.CallbackContext context)
    {
        if(canMove && canControl)
        {
            if(context.performed && isMoving)
            {
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
                    Invoke("ResetSpeed", sideBoostDuration);
                    return;
                }
                Debug.Log("Initial Strafe");
                isInvicible = true;
                shotsDismissal = true;
                canSideDash = true;
                Invoke("DeactivateDismissal", dismissalDuration);
                Invoke("DeactivateSideDash", sideBoostWindowDuration);
                Invoke("DeactivateInvicible", dashInvicibilityDuration);
                Invoke("CooldownSideDash", sideDashCooldown);
            }
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

    #region Barrel Roll

    public void BRoll(InputAction.CallbackContext context)
    {
        if(context.performed && canBRoll && canMove && canControl)
        {
            BarrelHBox.SetActive(true);
            canBRoll = false;
            Invoke("EndBRoll", 1f);
            Invoke("CooldownBarrelRoll", barrelRollCD);
        }
    }

    public void EndBRoll()
    {
        BarrelHBox.SetActive(false);
    }

    public void CooldownBarrelRoll()
    {
        canBRoll = true;
    }

    #endregion

    public void DeactivateOverBoost()
    {
        if(megaBoostExtend)
        {
            Invoke("DeactivateOverBoost", megaBoostDuration);
            megaBoostExtend = false;
            return;
        }
        actualBoostSpeed = boostTrailSpeed;
        megaBoostSecurity = false;
    }


}