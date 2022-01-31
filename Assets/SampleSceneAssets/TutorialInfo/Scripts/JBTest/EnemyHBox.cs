using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyHBox : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Bullet"))
        {
            gameObject.GetComponentInParent<Enemy>().spawned = false;
            other.gameObject.transform.position = new Vector3 (0, -10000, 0);
            gameObject.GetComponent<CinemachineDollyCart>().m_Speed = 0f;
            gameObject.GetComponentInParent<Enemy>().transform.position = new Vector3(0, -12000, 0);
            gameObject.GetComponent<CinemachineDollyCart>().m_Position = 0f;
            gameObject.GetComponentInParent<Enemy>().gameObject.SetActive(false);
        }
    }
}
