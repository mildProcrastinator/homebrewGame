using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyObject : ScriptableObject
{
    [Header("EnemyGameObjectScript")]
    public Enemy enemy;
    public Ground ground;
    public Rigidbody2D rb;
    public Seeker seeker;
    [Header("Pathfinder")]
    public GameObject target;
    public float activatedDistance;
    public float pathUpdateSeconds;

    [Header("Physics")]
    public float speed;
    public float nexWaypointDistance;
    public float jumpNodeHeightRequirement;
    public float jumpModifer;
    public float jumpCheckOffset;
    public Move movement;

    [Header("Custom Behavior")]
    public bool followEnabled;
    public bool jumpEnabled;
    public bool directionLookEnabled;

    private Path path;
    private int currentWaypoint = 0;
    private bool onGround;

    public void GetComponents(Enemy enemy) 
    {
        enemy = this.enemy;
        ground = enemy.GetComponent<Ground>();
        rb = enemy.GetComponent<Rigidbody2D>();
        seeker = enemy.GetComponent<Seeker>();

        //InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);    This needs to be somewhere either here or in enemy script
    }
    public void UpdatePath() 
    {
       // if (followEnabled && TargetInDistance() && seeker.IsDone()) 
      //  {
       //     seeker.StartPath(rb.position, target.position, OnPathComplete);
       // }
    }
    private void PathFollow() 
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

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        //jump
        if (onGround && jumpEnabled) 
        {
            if( direction.y >jumpNodeHeightRequirement)
            {
                //retrivejumpinput(); 
            }        
        }
        //move
        



        //calculate next waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nexWaypointDistance) 
        {
            currentWaypoint++;
        }

        if (directionLookEnabled) 
        {
            if (rb.velocity.x > 0.05f)
            {
                //face right
            }
            else if (rb.velocity.x < -0.05f)
            {
                //face left
            }
        }
    }




    
}
