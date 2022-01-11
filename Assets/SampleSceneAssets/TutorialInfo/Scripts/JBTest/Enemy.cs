using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public List<GameObject> posList = new List<GameObject>();

    private Vector3 nextPos;
    private int nextPosInt;
    public GameObject circlePoint;
    public int circlePos;
    public float speed = 20f;

    void Start()
    {
        nextPosInt = 0;
        nextPos = posList[nextPosInt].transform.position;
        GetCirclePoint();
    }

    private void Update() 
    {
        if(transform.position != nextPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        else
        {
            if(nextPosInt == posList.Count)
            {
                nextPosInt = circlePos;
            }
            else
            {
                nextPos = posList[nextPosInt].transform.position;
                nextPosInt++;
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.transform.position = new Vector3 (0, -10000, 0);
            gameObject.transform.position = new Vector3(0, -12000, 0);
        }
    }
    
    public void GetCirclePoint()
    {
        for(int i = 0; i < posList.Count; i++)
        {
            if(circlePoint == posList[i].gameObject)
            {
                circlePos = i;
            }
        }
    }
}
