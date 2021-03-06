using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [Header("Paramètres de la balle")]
    [Space(10)]
    [Tooltip("Vitesse de la balle")]
    public float bulletSpeed = 20f;
    [Tooltip("Portée maximum de la balle")]
    public float bulletRange = 100f;

    private float travelledDistance;

    [HideInInspector]
    public Vector3 velocity = Vector3.forward;

    private void Awake() 
    {
        travelledDistance = 0f;
    }

    private void Update() 
    {
        Vector3 velMetersPerFrame = velocity * Time.deltaTime * bulletSpeed;
        transform.position += transform.TransformDirection(velMetersPerFrame);
        travelledDistance += (velMetersPerFrame.z * 100) * Time.deltaTime;
        if(travelledDistance > bulletRange)
        {
            Destroy(gameObject);
        }

    }
}
