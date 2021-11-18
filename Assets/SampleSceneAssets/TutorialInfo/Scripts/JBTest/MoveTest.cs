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
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    [Header("Valeur de vitesse de côté")]
    [Space(10)]
    [Tooltip("Valeur de vitesse utilisé pour le déplacement en X et Y de Ray")]
    public float strafeSpeed = 20f;
    


    private void Awake() 
    {
        aInput = new AccelerateInput();
        rbCharacter = transform.GetChild(0).GetComponent<Rigidbody>();
    }


    // Fonction qui sert a donner le mouvement en X et Y de ray
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 rawMoveInput = context.ReadValue<Vector2>();
        Debug.Log(rawMoveInput);
        rbCharacter.velocity = rawMoveInput * strafeSpeed;
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
        rbCharacter.velocity = moveInput * strafeSpeed;
    }


    // Fonction qui sert a augmenter la vitesse sur l'axe Z
    public void Accelerate(InputAction.CallbackContext context)
    {
        Debug.Log("Ohlala on va vite");
        if(context.performed)
        {
        playerParent.m_Speed = boostTrailSpeed;
        }
        else{
            playerParent.m_Speed = trailSpeed;
        }
    }

    // Fonction qui sert a baisser la vitesse sur l'axe Z
    public void SlowDown(InputAction.CallbackContext context)
    {
        Debug.Log("Ohlala on ralentit");
    }

}
