using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{

    [Header("Variables Utiles")]
    [Space(10)]
    [Tooltip("Le personnage qui se déplace, le raycast des tirs part d'ici")]
    public GameObject characterModel;


    [Header("Variables de tir")]
    [Space(10)]
    [Tooltip("Le temps avant le debut de l'entrée dams le second tir")]
    public float timeBeforeSecondaryShot;

    [Space(10)]
    [Tooltip("Portée du raycast de secondary shot")]
    public float range = 1000f;

    private GameObject ray;
    private GameObject nug;
    private GameObject target;

    [Header("Balle")]
    [Space(10)]
    [Tooltip("Balle")]
    public GameObject bullet;

    #region Shot Variables
    private Vector3 secondaryShotAim;
    private bool activateSecondaryTimer;
    private float secondaryTimer = 0f;

    private bool secondaryShot;

    #endregion


    private void Awake() 
    {
        ray = transform.GetChild(0).gameObject;
        nug = ray.transform.GetChild(4).gameObject;
        target = ray.transform.GetChild(0).gameObject;
    }
    private void Start() 
    {
        
    }

    private void Update()
    {

        if(activateSecondaryTimer && !secondaryShot)
        {
            secondaryTimer += Time.deltaTime; 
        }

        if(secondaryTimer >= timeBeforeSecondaryShot && !secondaryShot)
        {
            secondaryShot = true;
        }

        #region Raycast For Secondaryshot

        secondaryShotAim = characterModel.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(characterModel.transform.position, secondaryShotAim * 50, Color.green);

        RaycastHit Hit;
        if( Physics.Raycast(transform.position, secondaryShotAim, out Hit, range) && secondaryShot)
        {
            if( Hit.collider.CompareTag("Enemy") )
                        {
                            Debug.Log("Touché en secondaire");
                        }
        }
        #endregion
    }

    public void Shooting(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Vector3 dir = target.transform.position - nug.transform.position;
            Quaternion bulletRotation = Quaternion.LookRotation(dir, nug.transform.InverseTransformDirection(nug.transform.up));
            Instantiate(bullet, nug.transform.position, bulletRotation, gameObject.transform);
            activateSecondaryTimer = true;
        }
        if(context.canceled)
        {
            activateSecondaryTimer = false;
            secondaryTimer = 0f;
            secondaryShot = false;
        }
    }
}

