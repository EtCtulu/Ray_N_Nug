using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrimpBomb : MonoBehaviour
{
    [Header("Paramètres de la bombe")]
    [Space(10)]
    [Tooltip("Vitesse de la bombe")]
    public float bombSpeed = 20f;
    [Tooltip("Portée maximum de la bombe")]
    public float bombRange = 100f;

    private float travelledDistance;

    [HideInInspector]
    public Vector3 velocity = Vector3.forward;

    private void Awake() 
    {
        travelledDistance = 0f;
    }

    private void Update() 
    {
        Vector3 velMetersPerFrame = velocity * Time.deltaTime * bombSpeed;
        transform.position += transform.TransformDirection(velMetersPerFrame);
        travelledDistance += (velMetersPerFrame.z * 100) * Time.deltaTime;
        if(travelledDistance > bombRange)
        {
            Destroy(gameObject);
        }
    }
}
