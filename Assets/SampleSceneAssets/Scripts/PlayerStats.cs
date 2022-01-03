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
}
