using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    public float speed;
    public float jumpForce;
    public Camera MainCamera;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;

    float HorizontalInput = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Awake()
    {
         rb = this.GetComponent<Rigidbody2D>();
    }
    //fixed frame update based on editor
    private void  FixedUpdate()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(HorizontalInput * speed, rb.velocity.y);
        if (Input.GetKey(KeyCode.Space) && isGrounded()) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        //Animation logic
        if (HorizontalInput > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (HorizontalInput < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else 
        {
            anim.SetBool("running", false);
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
