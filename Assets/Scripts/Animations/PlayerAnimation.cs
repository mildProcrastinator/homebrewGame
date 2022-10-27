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
        //Animation logic
        if (direction > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (direction < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
