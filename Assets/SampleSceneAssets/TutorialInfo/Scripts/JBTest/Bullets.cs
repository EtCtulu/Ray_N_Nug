using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour, IPooledObject
{
    [Header("Paramètres de la balle")]
    [Space(10)]
    [Tooltip("Vitesse de la balle")]
    public float bulletSpeed = 20f;
    [Tooltip("Portée maximum de la balle")]
    public float bulletRange = 100f;

    private float travelledDistance;

    Vector3 velocity = Vector3.forward;

    private bool shooted;

    private void Awake() 
    {
        shooted = false;
    }

    public void OnObjectSpawn()
    {
        shooted = true;
        travelledDistance = 0f;
    }

    private void Update() 
    {
        if(shooted)
        {
            Vector3 velMetersPerFrame = velocity * Time.deltaTime * bulletSpeed;
            transform.position += transform.TransformDirection(velMetersPerFrame);
            travelledDistance += (velMetersPerFrame.z * 100) * Time.deltaTime;
            if(travelledDistance > bulletRange)
            {
                gameObject.transform.position = new Vector3(0, -10000, 0);
                shooted = false;
            }
        }
    }
}
