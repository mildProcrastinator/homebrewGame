using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AIController", menuName = "InputController/AIController")]
public class AIController : InputController
{
    public EnemyObject brain;

    public override bool RetreiveJumpInput()
    {
        //return brain.DesiredJump()
        return true;

    }

    public override float RetreiveMoveInput()
    {
        return brain.direction.x;
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
}
