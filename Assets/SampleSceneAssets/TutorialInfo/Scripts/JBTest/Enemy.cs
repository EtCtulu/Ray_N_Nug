using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPooledObject
{
    private bool spawned;
    private GameObject enemyCart;

    private void Awake() 
    {
        spawned = false;
        enemyCart = gameObject.transform.GetChild(0).gameObject;
        gameObject.SetActive(false);
    }
    public void OnObjectSpawn()
    {
        spawned = true;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.transform.position = new Vector3 (0, -10000, 0);
            gameObject.transform.position = new Vector3(0, -12000, 0);
        }
    }
}
