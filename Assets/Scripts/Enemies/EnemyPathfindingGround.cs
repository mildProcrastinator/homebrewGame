using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyPathfindingGround : MonoBehaviour
{
    [Header("EnemyGameObjectScript")]
    
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
    public float jumpTimer;
    private float jumpTargetTime = 1;
    public Vector2 direction;

    [Header("Custom Behavior")]
    public bool followEnabled;
    public bool jumpEnabled;
    public bool directionLookEnabled;
    public bool desiredJump = false;
    public Ground ground;
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
        controller = (AIController)GetComponent<EnemyControllerManager>().controller;
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
        Vector2 jumpDirection = ((Vector2)path.vectorPath[currentWaypoint] - rb.position);
        //jump
        if (onGround && jumpEnabled && jumpTargetTime>0) 
        {
          
            if (jumpDirection.y > jumpNodeHeightRequirement)
            {
                controller.desiredJump = true;
                jumpTargetTime = -jumpTimer;
            }
            else 
            {
                controller.desiredJump = false;
            }
            
            Debug.Log("Jump Time" + jumpTargetTime);
        }
        else 
        {
            controller.desiredJump = false;
        }
        jumpTargetTime += Time.deltaTime;
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
