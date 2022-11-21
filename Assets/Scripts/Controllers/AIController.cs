using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AIController", menuName = "InputController/AIController")]
public class AIController : InputController
{
    public bool desiredJump;
    public float direction;
    public override bool RetreiveJumpInput()
    {
        return desiredJump;
        //return true;

    }

    public override float RetreiveMoveInput()
    {
        return direction;
        //return 1f;
    }
    public override bool RetreiveShootInput()
    {
        return true;
    }
    public override bool RetreiveMeleeInput()
    {
        return true;
    }
    public void SetDirection(float d) 
    {
        direction = d;
    }

}
