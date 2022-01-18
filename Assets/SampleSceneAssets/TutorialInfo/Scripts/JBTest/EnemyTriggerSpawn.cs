using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerSpawn : MonoBehaviour
{
    ObjectSpawner enemySpawn;
    public GameObject spawnPoint;

    public int enemiesToSpawn;

    public List<GameObject> enemiesSpawned;

    private void Awake() 
    {
        enemySpawn = ObjectSpawner.Instance;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(spawnEnemies(enemiesToSpawn));
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            foreach(GameObject despawn in enemiesSpawned)
            {
                despawn.GetComponent<Enemy>().spawned = false;
                despawn.SetActive(false);
            }
            enemiesSpawned.Clear();
        }
    }

    private IEnumerator spawnEnemies(int enemyNum)
    {
        yield return new WaitForSeconds(.3f);
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
}
