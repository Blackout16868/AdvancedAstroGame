using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypointFollow : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    [SerializeField] LayerMask player;
    [SerializeField] Transform center;
    [SerializeField] float vision = 100f;
     int currentWaypointIndex = 0;
    [SerializeField] float speed = 1f;
    [SerializeField] Transform playerPos;


 private void Start() {
    
    }
    void Update()
    {
    
        if (Physics.CheckSphere(center.position, vision, player))
        {
            
            
             transform.position = Vector3.MoveTowards(transform.position,playerPos.position, speed * Time.deltaTime);
             return;
        }

        if (Vector3.Distance(transform.position,waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }


        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }

    public bool playerNear(){
        return Physics.CheckSphere(center.position, vision, player);
    }
}
