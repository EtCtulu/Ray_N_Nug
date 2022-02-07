using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRoll : MonoBehaviour
{

    private float randomAngle;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("EnemyBullet"))
        {
            randomAngle = Random.Range(-90f, 90f);
            other.transform.localRotation = Quaternion.Euler(other.transform.localRotation.x + randomAngle, other.transform.localRotation.y + 90f, other.transform.localRotation.z);
            Debug.Log(other.gameObject.transform.position);
            Debug.Log("Nope");
        }
    }
}
