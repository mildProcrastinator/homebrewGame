using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private InputController input = null;

    private Animator anim;
    private SpriteRenderer sprite;
    private Ground ground;
    private float direction;
    private bool facingRight = false;
    [SerializeField] private Camera cam;
    private Vector2 mousePosition;
    [SerializeField] private GameObject arm;
    // Start is called before the first frame update

    void Awake()
    {
        ground = GetComponent<Ground>();
        anim = GetComponent<Animator>();
        direction = input.RetreiveMoveInput();  
        sprite = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDir = mousePosition - new Vector2(this.transform.position.x, this.transform.position.y); ;
        UpdateFacingSide(aimDir);


        direction = input.RetreiveMoveInput();
        UpdateAnimationState();
    }

    private void UpdateFacingSide(Vector2 aimDir)
    {
        if (aimDir.x > 0 && facingRight)
        {
            Flip();
        }
        else if (aimDir.x < 0 && !facingRight) 
        {
            Flip();
        }
    }
    private void UpdateAnimationState()
    {


        //Animation logic
        if (direction > 0f)
        {
            anim.SetBool("running", true);
           
        }
        else if (direction < 0f )
        {
            anim.SetBool("running", true);
        }
        else if(direction == 0f)
        {
            anim.SetBool("running", false);
        }
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        arm.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

}
