using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SkeletonController", menuName = "InputController/AIController/SkeletonController")]
public class SkeletonController : AIController
{
    public override bool RetreiveJumpInput()
    {
        return true;
        //if not able to move forward jump
    }

    public override float RetreiveMoveInput()
    {
        //move back and forth without falling off platform.
        //if player close to this move towards player
        //if moving input but not moving move opposite direction
        return 1f;
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
