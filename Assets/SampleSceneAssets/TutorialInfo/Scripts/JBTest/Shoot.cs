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
    public float range = 10000f;

    private GameObject ray;
    private GameObject nug;
    private GameObject target;

    [Header("Game Objects")]
    [Space(10)]
    [Tooltip("Balle")]
    public GameObject bullet;

    public GameObject secondaryBullet;

    [Tooltip("Bombe Crevette")]
    public GameObject bombShrimp;

    [Space(10)]
    [Tooltip("Un objet vite a rajouter pour reset les locks")]
    //public GameObject empty;

    #region Shot Variables
    private Vector3 secondaryShotAim;
    private bool activateSecondaryTimer;
    private float secondaryTimer = 0f;

    private int ennemyIdx = 0;

    public GameObject[] ennemy = new GameObject[5];

    private bool secondaryShot;

    #endregion


    private void Awake() 
    {
        ray = transform.GetChild(0).gameObject;
        nug = ray.transform.GetChild(6).gameObject;
        target = ray.transform.GetChild(0).gameObject;
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

        Debug.DrawRay(characterModel.transform.position, secondaryShotAim * 10000, Color.green);

        if(secondaryShot){

        secondaryShotAim = characterModel.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(characterModel.transform.position, secondaryShotAim * 10000, Color.red);

        RaycastHit Hit;
        if( Physics.Raycast(characterModel.transform.position, secondaryShotAim, out Hit, range) && secondaryShot && Hit.transform.tag == "Enemy")
        {
            
                            Debug.Log("Touché en secondaire");
                           switch (ennemyIdx) {
                               case 0 :
                                   if(Hit.collider.gameObject != ennemy[0] && Hit.collider.gameObject != ennemy[1] && Hit.collider.gameObject != ennemy[2] && Hit.collider.gameObject != ennemy[3] && Hit.collider.gameObject != ennemy[4])
                                   {
                                       ennemy[0] = Hit.collider.gameObject;
                                       ennemyIdx++;
                                   }
                                   break;
                                case 1 :
                                   if(Hit.collider.gameObject != ennemy[0] && Hit.collider.gameObject != ennemy[1] && Hit.collider.gameObject != ennemy[2] && Hit.collider.gameObject != ennemy[3] && Hit.collider.gameObject != ennemy[4])
                                   {
                                       ennemy[1] = Hit.collider.gameObject;
                                       ennemyIdx++;
                                   }
                                   break;
                                case 2 :
                                   if(Hit.collider.gameObject != ennemy[0] && Hit.collider.gameObject != ennemy[1] && Hit.collider.gameObject != ennemy[2] && Hit.collider.gameObject != ennemy[3] && Hit.collider.gameObject != ennemy[4])
                                   {
                                       ennemy[2] = Hit.collider.gameObject;
                                       ennemyIdx++;
                                   }
                                   break;
                                case 3 :
                                   if(Hit.collider.gameObject != ennemy[0] && Hit.collider.gameObject != ennemy[1] && Hit.collider.gameObject != ennemy[2] && Hit.collider.gameObject != ennemy[3] && Hit.collider.gameObject != ennemy[4])
                                   {
                                       ennemy[3] = Hit.collider.gameObject;
                                       ennemyIdx++;
                                   }
                                   break;
                                case 4 :
                                   if(Hit.collider.gameObject != ennemy[0] && Hit.collider.gameObject != ennemy[1] && Hit.collider.gameObject != ennemy[2] && Hit.collider.gameObject != ennemy[3] && Hit.collider.gameObject != ennemy[4])
                                   {
                                       ennemy[4] = Hit.collider.gameObject;
                                       ennemyIdx++;
                                   }
                                   break;
                               default :
                                   
                                   break;
                           }
                        
        }
        #endregion
        }
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
            if(secondaryShot)
            {
                secondaryShot = false;
                for(int i = 0; i >= 4 ; i++) 
                {
                    SecondaryShot();
                }
                ennemyIdx = 0;
                ennemy[0] = null;
                ennemy[1] = null;
                ennemy[2] = null;
                ennemy[3] = null;
                ennemy[4] = null;

            }

        }
    }

    public void SecondaryShot()
    {
        Vector3 dir = target.transform.position - nug.transform.position;
        Quaternion bulletRotation = Quaternion.LookRotation(dir, nug.transform.InverseTransformDirection(nug.transform.up));
        Instantiate(secondaryBullet, nug.transform.position, bulletRotation, gameObject.transform);
    }

    public void Bomb(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Vector3 dir = target.transform.position - nug.transform.position;
            Quaternion bulletRotation = Quaternion.LookRotation(dir, nug.transform.InverseTransformDirection(nug.transform.up));
            Instantiate(bombShrimp, nug.transform.position, bulletRotation, gameObject.transform);
        }
    }
}

