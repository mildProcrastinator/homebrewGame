using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyObject : MonoBehaviour
{
    [Header("EnemyGameObjectScript")]
    public Ground ground;
    public Rigidbody2D rb;
    public Seeker seeker;
    public AIController controller;
    [Header("Pathfinder")]
    public GameObject target;
    public string targetTag;
    public float activatedDistance;
    public float pathUpdateSeconds;

    [Header("Physics")]
    public float speed;
    public float nexWaypointDistance;
    public float jumpNodeHeightRequirement;
    public float jumpDistanceToTarget;
    public float jumpCheckOffset;
    public Vector2 direction;

    [Header("Custom Behavior")]
    public bool followEnabled;
    public bool jumpEnabled;
    public bool directionLookEnabled;
    public bool desiredJump = false;

    private Path path;
    private int currentWaypoint = 0;
    private bool onGround = false;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag);
        ground = this.GetComponent<Ground>();
        rb = this.GetComponent<Rigidbody2D>();
        seeker = this.GetComponent<Seeker>();
        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }
    public void UpdatePath() 
    {
        
       if (followEnabled && TargetInDistance() && seeker.IsDone()) 
       {
           seeker.StartPath(rb.position, target.transform.position, OnPathComplete);
       }

    }
    public void FixedUpdate() 
    {
        if (TargetInDistance() && followEnabled) 
        {
            PathFollow();
        }
       
    }
    public void PathFollow() 
    {
        if (path == null) 
        {
            return;
        }

        //REACH END OF PATH
        if (currentWaypoint >= path.vectorPath.Count) 
        {
            return;
        }
        onGround = ground.GetOnGround();

        direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        //jump
        if (onGround && jumpEnabled) 
        {
          
            if (direction.y > jumpNodeHeightRequirement)
            {
                controller.desiredJump = true;
            }
            else 
            {
                controller.desiredJump = false;
            }
        }

        //move
        controller.SetDirection(direction.x);


        //calculate next waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        
       
        if (distance < nexWaypointDistance) 
        {
            currentWaypoint++;
        }
    }
    public bool TargetInDistance() 
    {
        return Vector2.Distance(rb.transform.position, target.transform.position) < activatedDistance;
    }

    public void OnPathComplete(Path p) 
    {
        if (!p.error) 
        {
            path = p;
            currentWaypoint = 0;
            
        }
    }


}
