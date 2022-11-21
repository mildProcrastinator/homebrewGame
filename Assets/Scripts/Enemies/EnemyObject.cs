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
    private int currentWaypoint;
    private bool onGround;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag);
        ground = this.GetComponent<Ground>();
        rb = this.GetComponent<Rigidbody2D>();
        seeker = this.GetComponent<Seeker>();
        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }
    public void Update() 
    {
        
       if (followEnabled && TargetInDistance() && seeker.IsDone()) 
       {
            Debug.Log("Updating Path");
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

        if (currentWaypoint >= path.vectorPath.Count) 
        {
            return;
        }
        onGround = ground.GetOnGround();

        direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        Debug.Log("on ground: "+onGround);
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
