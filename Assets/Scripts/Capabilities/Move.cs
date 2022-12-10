using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 1000f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float maxAirAcceleration = 20f;

    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D body;
    private Ground ground;

    private float maxSpeedChange;
    private float acceleration;
    private bool onGround;


    private void Start()
    {
        if (this.gameObject.CompareTag("Enemy")) 
        {
            input = GetComponent<EnemyControllerManager>().controller;
        }
            
    }
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        
    }

    void Update()
    {
        direction.x = input.RetreiveMoveInput();
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - ground.GetFriction(), 0);
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        Debug.Log(velocity.x + gameObject.transform.root.GetComponentInChildren<Rigidbody2D>().velocity.x);
        velocity = body.velocity;

        acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        bool alreadyOnPlatform = false;
        //  is on moving platform
        if (gameObject.transform.root.name.Contains("Moving Platform") && alreadyOnPlatform == false)
        {
            velocity.x = Mathf.Clamp(gameObject.transform.root.GetComponentInChildren<Rigidbody2D>().velocity.x + velocity.x,-maxSpeed,maxSpeed);
            alreadyOnPlatform = true;
        }// not on platform
        else if (!gameObject.transform.root.name.Contains("Moving Platform"))
        {
            alreadyOnPlatform = false;
        }
        body.velocity = velocity;
    }

    public void SetMaxSpeed(float speed) 
    {
        maxSpeed = speed;
    }
}
