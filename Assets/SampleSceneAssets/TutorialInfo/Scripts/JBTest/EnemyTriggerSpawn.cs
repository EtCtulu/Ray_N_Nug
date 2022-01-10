using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerSpawn : MonoBehaviour
{
    ObjectSpawner enemySpawn;
    public GameObject spawnPoint;

    private void Awake() 
    {
        enemySpawn = ObjectSpawner.Instance;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(spawnEnemies(5));
        }
    }

    private IEnumerator spawnEnemies(int enemyNum)
    {
        yield return new WaitForSeconds(.3f);
        if(enemyNum != 0)
        {
            enemySpawn.SpawnObject("Enemy", spawnPoint.transform.position, spawnPoint.transform.rotation);
            enemyNum--;
            StartCoroutine(spawnEnemies(enemyNum));
        }
        else
        {
            StopCoroutine(spawnEnemies(0));
        }
    }
}
