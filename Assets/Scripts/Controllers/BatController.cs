using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BatController", menuName = "InputController/AIController/BatController")]
public class BatController : InputController
{

    public float direction;
    public float directionVerticle;
    public override bool RetreiveJumpInput()
    {
        return false;
        //return true;

    }

    public override float RetreiveMoveInput()
    {
        return direction;
        //return 1f;
    }
    public float RetreiveMoveInputVerticle()
    {
        return directionVerticle;
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
    public void SetDirectionVerticle(float v)
    {
        directionVerticle = v;
    }
}
