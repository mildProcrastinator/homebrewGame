using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private InputController input = null;

    private Animator anim;
    private SpriteRenderer sprite;
    private Ground ground;
    private float direction;
    private bool facingRight = false;
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
        direction = input.RetreiveMoveInput();
      
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {

        Debug.Log(direction);
        //Animation logic
        if (direction > 0f && facingRight)
        {
            anim.SetBool("running", true);
            Flip();
        }
        else if (direction < 0f && !facingRight) 
        {
            anim.SetBool("running", true);
            Flip();
        }
        else 
        {
            anim.SetBool("running", false);
        }
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

}
