using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats Du Personage")]
    [Space(10)]
    [Tooltip("La vie du personnage, un int, = 1 point de vie est égal a un dégat")]
    public static int playerHealth = 6;

    [Tooltip("Le boost du personnage, un float, de 0 a 100, marche comme un pourcentage")]
    public static float playerBoost = 100;
}
