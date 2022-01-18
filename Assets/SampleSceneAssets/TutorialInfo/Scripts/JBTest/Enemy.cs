using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPooledObject
{
    [HideInInspector]
    public bool spawned;
    private GameObject enemyCart;

    private GameObject player;

    public GameObject enemyProjectile;

    public float shootingCD = 1f;

    private bool isShooting = false;

    private void Awake() 
    {
        spawned = false;
        player = MoveTest.Instance.gameObject.transform.GetChild(0).GetChild(1).gameObject;
        enemyCart = gameObject.transform.GetChild(0).gameObject;
        gameObject.SetActive(false);
    }
    public void OnObjectSpawn()
    {
        spawned = true;
        gameObject.SetActive(true);
    }

    private void Update() 
    {
        if(spawned)
        {
            if(!isShooting)
            {
                isShooting = true;
                StartCoroutine(shootToPlayer());
            }
        }
        else
        {
            StopCoroutine(shootToPlayer());
            isShooting = false; 
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.transform.position = new Vector3 (0, -10000, 0);
            gameObject.transform.position = new Vector3(0, -12000, 0);
        }
    }

    private IEnumerator shootToPlayer()
    {

        yield return new WaitForSeconds(shootingCD);    
        //tirer vers le player
        Vector3 dir = player.transform.position - enemyCart.transform.position;
        Quaternion shootDir = Quaternion.LookRotation(dir, enemyCart.transform.InverseTransformDirection(enemyCart.transform.up));
        Instantiate(enemyProjectile, enemyCart.transform.position, shootDir);    
        isShooting = false;    
    }
}
