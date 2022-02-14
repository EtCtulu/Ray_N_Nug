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

    private MoveTest player;

    public GameObject[] ennemy = new GameObject[5];

    private bool secondaryShot;

    public PlayerStats stats;

    #endregion


    private void Awake() 
    {
        player = MoveTest.Instance;
        ray = transform.GetChild(0).gameObject;
        nug = ray.transform.GetChild(6).gameObject;
        target = ray.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if(player.canMove)
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
    }

    public void Shooting(InputAction.CallbackContext context)
    {
        if(player.canMove)
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

                    SecondaryShot(ennemyIdx);

                    secondaryShot = false;
                    /*for(int i = 0; i >= 4 ; i++) 
                    {
                        SecondaryShot();
                    }*/
                    ennemyIdx = 0;
                    ennemy[0] = null;
                    ennemy[1] = null;
                    ennemy[2] = null;
                    ennemy[3] = null;
                    ennemy[4] = null;

                }

            }
        }
    }

    public void SecondaryShot(int idx)
    {
        float boostGain;
        Vector3 dir = target.transform.position - nug.transform.position;
        Quaternion bulletRotation = Quaternion.LookRotation(dir, nug.transform.InverseTransformDirection(nug.transform.up));
        GameObject bullet;
       switch (ennemyIdx) {
           case 0:
               boostGain = stats.singleLockBoostGain;
               bullet = Instantiate(secondaryBullet, nug.transform.position, bulletRotation, gameObject.transform);
                bullet.GetComponent<SecondaryBullet>().boostGain = boostGain;
                bullet.GetComponent<SecondaryBullet>().ennemyLocked = ennemy[0];
               break;
            case 1: 
                boostGain = stats.twoLockBoostGain / 2;
                for(int i = 0; i >= 1 ; i++) {
                bullet = Instantiate(secondaryBullet, nug.transform.position, bulletRotation, gameObject.transform);
                bullet.GetComponent<SecondaryBullet>().boostGain = boostGain;
                bullet.GetComponent<SecondaryBullet>().ennemyLocked = ennemy[i];
                }
                break;
            case 2: 
                boostGain = stats.threeLockBoostGain / 3;
                for(int i = 0; i >= 2 ; i++) {
                bullet = Instantiate(secondaryBullet, nug.transform.position, bulletRotation, gameObject.transform);
                bullet.GetComponent<SecondaryBullet>().boostGain = boostGain;
                bullet.GetComponent<SecondaryBullet>().ennemyLocked = ennemy[i];
                }
                break;
            case 3: 
                boostGain = stats.fourLockBoostGain / 4;
                for(int i = 0; i >= 3 ; i++) {
                bullet = Instantiate(secondaryBullet, nug.transform.position, bulletRotation, gameObject.transform);
                bullet.GetComponent<SecondaryBullet>().boostGain = boostGain;
                bullet.GetComponent<SecondaryBullet>().ennemyLocked = ennemy[i];
                }
                break;
            case 4: 
                boostGain = stats.fiveLockBoostGain / 5;
                for(int i = 0; i >= 4 ; i++) {
                bullet = Instantiate(secondaryBullet, nug.transform.position, bulletRotation, gameObject.transform);
                bullet.GetComponent<SecondaryBullet>().boostGain = boostGain;
                bullet.GetComponent<SecondaryBullet>().ennemyLocked = ennemy[i];
                }
                break;
           default :
               
               break;
       }

        /*if(player.canMove)
        {
            Vector3 dir = target.transform.position - nug.transform.position;
            Quaternion bulletRotation = Quaternion.LookRotation(dir, nug.transform.InverseTransformDirection(nug.transform.up));
            Instantiate(secondaryBullet, nug.transform.position, bulletRotation, gameObject.transform);
        }*/
    }

    public void Bomb(InputAction.CallbackContext context)
    {
        if(context.performed && player.canMove)
        {
            Vector3 dir = target.transform.position - nug.transform.position;
            Quaternion bulletRotation = Quaternion.LookRotation(dir, nug.transform.InverseTransformDirection(nug.transform.up));
            Instantiate(bombShrimp, nug.transform.position, bulletRotation, gameObject.transform);
        }
    }
}

