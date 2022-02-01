using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRoll : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("EnemyBullet"))
        {
            //other.GetComponent<EnemyProjectile>().transform.rotation;
            Debug.Log(other.gameObject.transform.position);
            Debug.Log("Nope");
        }
    }
}
