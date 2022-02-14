using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats Du Personage")]
    [Space(10)]
    [Tooltip("La vie du personnage, un int, = 1 point de vie est égal a un dégat")]
    public int playerHealth = 6;

    [Tooltip("Le boost du personnage, un float, de 0 a 100, marche comme un pourcentage")]
    public float playerBoost = 100;

    [Tooltip("Le nombre de bombes que le personnage as a sa disposition, un int")]
    public int playerBombs = 4;

    [Header("Ennemis")]
    [Space(10)]
    [Tooltip("Le nombre d'ennemis lock, un int")]
    public int lockNumber = 0;

    [Header("Variables Gain de boost pour 1 ennemi tue")]
    [Space(10)]
    [Tooltip("Le gain de boost d'un kill seul")]
    public float singleBoostGain = 0;

    [Header("Variables Gain de boost pour ennemi lock")]
    [Space(10)]
    public float singleLockBoostGain = 0;
    public float twoLockBoostGain = 0;
    public float threeLockBoostGain = 0;
    public float fourLockBoostGain = 0;
    public float fiveLockBoostGain = 0;

    [Header("GameObject de l'UI")]
    [Space(10)]
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;
    public GameObject health6;
    [Space(10)]
    public TextMeshProUGUI textBombe;
    public TextMeshProUGUI textTimer;

    [Header("Movetest")]
    [Space(10)]
    public MoveTest moveTest;

    private float timeValue = 0;

    public void Awake()
    {
        
    }

    public void Update()
    {
        //textBombe.text = playerBombs.ToString();

        timeValue += 1 * Time.deltaTime;
        DisplayTime(timeValue);
    }

    // Transform timeToDisplay en 3 valeurs (minutes, seconde, milliseconde) 
    public void DisplayTime(float timeToDisplay)
    {
        float minute = Mathf.FloorToInt(timeToDisplay / 60);
        float seconde = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconde = timeToDisplay % 1 * 1000;

//        textTimer.text = string.Format("{0:00}:{1:00}:{2:000}", minute, seconde, milliseconde);
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        UiHealth();
    }

    //Affiche la vie en fonction de playerealth dans l'UI
    public void UiHealth()
    {
        if(playerHealth == 6)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
            health4.SetActive(true);
            health5.SetActive(true);
            health6.SetActive(true);
        }
        else if(playerHealth == 5)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
            health4.SetActive(true);
            health5.SetActive(true);
            health6.SetActive(false);
        }
        else if (playerHealth == 4)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
            health4.SetActive(true);
            health5.SetActive(false);
            health6.SetActive(false);
        }
        else if (playerHealth == 3)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
            health4.SetActive(false);
            health5.SetActive(false);
            health6.SetActive(false);
        }
        else if (playerHealth == 2)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(false);
            health4.SetActive(false);
            health5.SetActive(false);
            health6.SetActive(false);
        }
        else if (playerHealth == 1)
        {
            health1.SetActive(true);
            health2.SetActive(false);
            health3.SetActive(false);
            health4.SetActive(false);
            health5.SetActive(false);
            health6.SetActive(false);
        }
        else if (playerHealth == 0)
        {
            health1.SetActive(false);
            health2.SetActive(false);
            health3.SetActive(false);
            health4.SetActive(false);
            health5.SetActive(false);
            health6.SetActive(false);
        }
    }

    public void UseBomb()
    {
        playerBombs--;
    }

    public void GetBomb()
    {
        playerBombs++;
    }

    public void SingleBoostGain()
    {
        playerBoost += singleBoostGain;
        playerBoost = Mathf.Clamp(playerBoost, 0, 100);
    }
    public void LockBoostGain(int lockNumber)
    {
       switch (lockNumber) {
           case 0:
                playerBoost += singleLockBoostGain;
                playerBoost = Mathf.Clamp(playerBoost, 0, 100);
               break;
            case 1:
                playerBoost += twoLockBoostGain;
                playerBoost = Mathf.Clamp(playerBoost, 0, 100);
               break;
            case 2:
                playerBoost += threeLockBoostGain;
                playerBoost = Mathf.Clamp(playerBoost, 0, 100);
               break;
            case 3:
                playerBoost += fourLockBoostGain;
                playerBoost = Mathf.Clamp(playerBoost, 0, 100);
               break;
            case 4:
                playerBoost += fiveLockBoostGain;
                playerBoost = Mathf.Clamp(playerBoost, 0, 100);
               break;
           default :
               
               break;
       }
    }
}
