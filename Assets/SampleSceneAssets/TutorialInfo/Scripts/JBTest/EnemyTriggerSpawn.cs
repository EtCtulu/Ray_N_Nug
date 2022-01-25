using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyTriggerSpawn : MonoBehaviour
{
    ObjectSpawner enemySpawn;
    public GameObject spawnPoint;

    public float spawnCD = .3f;

    public float stoppingTimer = 5f;

    public int enemiesToSpawn;

    public List<GameObject> enemiesSpawned;

    private bool enemiesStopped;

    private void Awake() 
    {
        enemySpawn = ObjectSpawner.Instance;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(spawnEnemies(enemiesToSpawn));
            enemiesStopped = false;
        }
    }

    private void Update() 
    {
        if (enemiesSpawned.Count == enemiesToSpawn && !enemiesStopped)
        {
            enemiesStopped = true;
            foreach(GameObject stopping in enemiesSpawned)
            {
                StartCoroutine(stopEnemies(stopping));
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            foreach(GameObject despawn in enemiesSpawned)
            {
                despawn.GetComponent<Enemy>().spawned = false;
            }
            enemiesSpawned.Clear();
        }
    }

    private IEnumerator spawnEnemies(int enemyNum)
    {
        yield return new WaitForSeconds(spawnCD);
        if(enemyNum != 0)
        {
            enemiesSpawned.Add(enemySpawn.SpawnObject("Enemy", spawnPoint.transform.position, spawnPoint.transform.rotation));
            enemyNum--;
            StartCoroutine(spawnEnemies(enemyNum));
        }
        else
        {
            StopCoroutine(spawnEnemies(0));
        }
    }

    private IEnumerator stopEnemies(GameObject enemies)
    {
        yield return new WaitForSeconds(stoppingTimer - spawnCD * enemiesSpawned.Count);
        enemies.GetComponent<Enemy>().enemyCart.GetComponent<CinemachineDollyCart>().m_Speed = 0f;
        StopCoroutine(stopEnemies(enemies));
    }
}
