using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats Du Personage")]
    [Space(10)]
    [Tooltip("La vie du personnage, un int, = 1 point de vie est égal a un dégat")]
    public int playerHealth = 6;

    [Tooltip("Le boost du personnage, un float, de 0 a 100, marche comme un pourcentage")]
    public float playerBoost = 100;

    [Tooltip("Le nombre de bombes que le personnage as a sa disposition, un int")]
    public int playerBombs = 0;

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

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
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
