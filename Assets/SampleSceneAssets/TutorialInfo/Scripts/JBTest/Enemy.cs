using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Enemy : MonoBehaviour, IPooledObject
{
    //[HideInInspector]
    public bool spawned;

    [HideInInspector]
    public GameObject enemyCart;

    private GameObject player;

    public GameObject enemyProjectile;

    public float shootingCD = 3f;

    public float movingSpeed = 15f;

    private bool isShooting = false;

    private void Awake() 
    {
        spawned = false;
        player = MoveTest.Instance.gameObject.transform.GetChild(0).GetChild(2).gameObject;
        enemyCart = gameObject.transform.GetChild(0).gameObject;
        gameObject.SetActive(false);
    }

    public void OnObjectSpawn()
    {
        spawned = true;
        isShooting = false;
        enemyCart.GetComponent<CinemachineDollyCart>().m_Position = 0f;
        enemyCart.GetComponent<CinemachineDollyCart>().m_Speed = movingSpeed;   
        gameObject.SetActive(true);
    }

    private void Update() 
    {
        if(spawned)
        {
            if(!isShooting && enemyCart.GetComponent<CinemachineDollyCart>().m_Speed == 0f)
            {
                isShooting = true;
                StartCoroutine(shootToPlayer());
            }
        }
        else
        {
            StopCoroutine(shootToPlayer());
            enemyCart.GetComponent<CinemachineDollyCart>().m_Speed = movingSpeed;
            isShooting = false; 
            if(enemyCart.GetComponent<CinemachineDollyCart>().m_Position == enemyCart.GetComponent<CinemachineDollyCart>().m_Path.PathLength)
            {
                gameObject.SetActive(false);
            }
        }
    }

    /*private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.transform.position = new Vector3 (0, -10000, 0);
            StopCoroutine(shootToPlayer());
            enemyCart.GetComponent<CinemachineDollyCart>().m_Speed = 0f;
            gameObject.transform.position = new Vector3(0, -12000, 0);
            enemyCart.GetComponent<CinemachineDollyCart>().m_Position = 0f;
            spawned = false;
            gameObject.SetActive(false);
        }
    }*/

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
