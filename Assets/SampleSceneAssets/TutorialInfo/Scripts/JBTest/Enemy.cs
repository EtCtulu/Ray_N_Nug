using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Enemy : MonoBehaviour, IPooledObject
{
    [HideInInspector]
    public bool spawned;
    private GameObject enemyCart;

    private GameObject player;

    public GameObject enemyProjectile;

    public float shootingCD = 1f;

    private bool isShooting = false;

    public CinemachinePathBase goingPath;
    public CinemachinePathBase startingPath;

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
        enemyCart.GetComponent<CinemachineDollyCart>().m_Path = startingPath;
        enemyCart.GetComponent<CinemachineDollyCart>().m_Speed = 10f;
        enemyCart.GetComponent<CinemachineDollyCart>().m_Position = 0f;
        gameObject.SetActive(true);
    }

    private void Update() 
    {
        if(spawned)
        {
            if(enemyCart.GetComponent<CinemachineDollyCart>().m_Position == enemyCart.GetComponent<CinemachineDollyCart>().m_Path.PathLength)
            {
                enemyCart.GetComponent<CinemachineDollyCart>().m_Path = goingPath;
                enemyCart.GetComponent<CinemachineDollyCart>().m_Position = 0f;
                gameObject.transform.SetParent(null);
            }
            if(!isShooting)
            {
                isShooting = true;
                StartCoroutine(shootToPlayer());
            }
        }
        else
        {
            StopCoroutine(shootToPlayer());
            enemyCart.GetComponent<CinemachineDollyCart>().m_Speed = 0f;
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
