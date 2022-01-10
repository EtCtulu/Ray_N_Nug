using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 velocity = Vector3.forward;
    public float bulletSpeed = 20f;
    private void Update() 
    {
         Vector3 velMetersPerFrame = velocity * Time.deltaTime * bulletSpeed;
        transform.position += transform.TransformDirection(velMetersPerFrame);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.transform.position = new Vector3 (0, -10000, 0);
            gameObject.transform.position = new Vector3(0, -12000, 0);
        }
    }
}
