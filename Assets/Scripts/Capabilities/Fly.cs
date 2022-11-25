using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] private BatController input = null;
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


    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
    }
    private void Start()
    {
        input = (BatController)GetComponent<EnemyControllerManager>().controller;
    }
    void Update()
    {
        direction.x = input.RetreiveMoveInput();
        direction.y = input.RetreiveMoveInputVerticle();
        desiredVelocity = new Vector2(direction.x, direction.y) * Mathf.Max(maxSpeed - ground.GetFriction(), 0);
    }

    private void FixedUpdate()
    {
        velocity = body.velocity;

        acceleration = maxAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.y = Mathf.MoveTowards(velocity.y, desiredVelocity.y, maxSpeedChange);
        body.velocity = velocity;
    }
}
