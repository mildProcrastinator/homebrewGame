using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    
    Rigidbody2D rb;
    private BoxCollider2D coll;
    public float speed;
    public float jumpForce;
    public Camera MainCamera;

    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }
    private void Awake()
    {
         rb = this.GetComponent<Rigidbody2D>();
    }
    //fixed frame update based on editor
    private void  Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(HorizontalInput * speed, rb.velocity.y);
        if (Input.GetKey(KeyCode.Space) && isGrounded()) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    //called after all other update functions
    private void LateUpdate()
    {
        
      
    }
    private bool isGrounded() 
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
