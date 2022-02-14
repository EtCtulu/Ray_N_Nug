using System.Data;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyHBox : MonoBehaviour
{
    public PlayerStats stats;
    
    private bool startDestroy = false;
    private GameObject bomb;

    private MoveTest player;

    private float originalSpeed;

    private bool isRecovering;

    void Awake()
    {
        stats = GameObject.FindGameObjectWithTag("CharacterParent").GetComponent<PlayerStats>();
        player = MoveTest.Instance;
        isRecovering = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Bullet"))
        {
            stats.SingleBoostGain();
            gameObject.GetComponent<CinemachineDollyCart>().m_Position = gameObject.GetComponent<CinemachineDollyCart>().m_Path.PathLength;
            gameObject.GetComponentInParent<Enemy>().spawned = false;
            Destroy(other);
            gameObject.GetComponent<CinemachineDollyCart>().m_Speed = 0f;
            gameObject.GetComponentInParent<Enemy>().transform.position = new Vector3(0, -12000, 0); 
            gameObject.GetComponentInParent<Enemy>().gameObject.SetActive(false);
        }
        else if (other.CompareTag("Bomb"))
        {
            bomb = other.gameObject; 
            startDestroy = true;
            other.GetComponent<ShrimpBomb>().bombSpeed = 0f;
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (other.CompareTag("Player"))
        {
            originalSpeed = player.trailSpeed;
            Debug.Log("Ouille");
            player.trailSpeed -= 3f;
            player.canMove = false;
            Invoke("Recovery", .2f);
        }
    }

    private void Update() 
    {
        if(startDestroy)
        {
            gameObject.GetComponent<CinemachineDollyCart>().m_Position = gameObject.GetComponent<CinemachineDollyCart>().m_Path.PathLength;
            gameObject.GetComponentInParent<Enemy>().spawned = false;
            gameObject.GetComponent<CinemachineDollyCart>().m_Speed = 0f;
            gameObject.GetComponentInParent<Enemy>().transform.position = new Vector3(0, -12000, 0); 
            gameObject.GetComponentInParent<Enemy>().gameObject.SetActive(false);
            Invoke("DestroyBomb", 1f);
        }

        if(isRecovering && player.trailSpeed < originalSpeed)
        {
            player.trailSpeed += 1.5f * Time.deltaTime * 5;      
        }
    }

    public void DestroyBomb()
    {
        Destroy(bomb);
        startDestroy = false;
    }

    public void Recovery()
    {
        player.canMove = true;
        isRecovering = true;
    }
}
