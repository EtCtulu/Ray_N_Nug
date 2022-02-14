using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBox : MonoBehaviour
{
    
    private MoveTest player;

    private float originalSpeed;

    private bool isRecovering;

    private void Awake() 
    {
        player = MoveTest.Instance;
        isRecovering = false;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            originalSpeed = player.trailSpeed;
            Debug.Log("Ouille");
            player.trailSpeed -= 3f;
            player.canControl = false;
            Invoke("Recovery", .2f);
        }
    }
    
    private void Update() 
    {
        if(isRecovering && player.trailSpeed < originalSpeed)
        {
            player.trailSpeed += 1.5f * Time.deltaTime * 5;      
        }
    }

    public void Recovery()
    {
        player.canControl = true;
        isRecovering = true;
    }
}
