using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyObject : ScriptableObject
{
    [Header("EnemyGameObjectScript")]
    public Ground ground;
    public Rigidbody2D rb;
    public Seeker seeker;
    [Header("Pathfinder")]
    public GameObject target;
    public string targetTag;
    public float activatedDistance;
    public float pathUpdateSeconds;

    [Header("Physics")]
    public float speed;
    public float nexWaypointDistance;
    public float jumpNodeHeightRequirement;
    public float jumpModifer;
    public float jumpCheckOffset;
    public Vector2 direction;

    [Header("Custom Behavior")]
    public bool followEnabled;
    public bool jumpEnabled;
    public bool directionLookEnabled;
    public bool desiredJump = false;

    private Path path;
    private int currentWaypoint = 0;
    private bool onGround;

    public void GetComponents(Ground g, Seeker s, Rigidbody2D r) 
    {
        target = GameObject.FindGameObjectWithTag(targetTag);
        ground = g.GetComponent<Ground>();
        rb = r.GetComponent<Rigidbody2D>();
        seeker = s.GetComponent<Seeker>();

        
    }
    public void UpdatePath() 
    {
        
       if (followEnabled && TargetInDistance() && seeker.IsDone()) 
       {
            Debug.Log("Updating Path");
           seeker.StartPath(rb.position, target.transform.position, OnPathComplete);
       }
    }
    public void FixedUpdatePath() 
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
                desiredJump = true;
            }
            else 
            {
                desiredJump = false;
            }
        }
        
        //move
        



        //calculate next waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nexWaypointDistance) 
        {
            currentWaypoint++;
        }

       // if (directionLookEnabled) 
        //{
        //    if (rb.velocity.x > 0.05f)
        //    {
                //face right
        //    }
        //    else if (rb.velocity.x < -0.05f)
          //  {
                //face left
        //    }
       // }
    }
    public bool TargetInDistance() 
    {
        return Vector2.Distance(rb.transform.position, target.transform.position)< activatedDistance;
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
