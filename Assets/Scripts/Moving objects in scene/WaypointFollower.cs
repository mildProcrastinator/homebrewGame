using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    private Vector2 velocity;
    private Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        
    }
    private void FixedUpdate()
    {
        velocity = body.velocity;

        if (waypoints[currentWaypointIndex].transform.position.x - transform.position.x > 0)
        {
            velocity.x = speed;
        }
        else
        {
            velocity.x = -speed;
        }

        body.velocity = velocity;
        
    }
}
