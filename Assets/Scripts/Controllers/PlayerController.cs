using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerController", menuName = "InputController/PlayerController")]
public class PlayerController : InputController
{
    public override bool RetreiveJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }

    public override float RetreiveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public override bool RetreiveShootInput()
    {
        return Input.GetButtonDown("Fire2");
    }

    public override bool RetreiveMeleeInput()
    {
        return Input.GetButtonDown("Fire1");
    }
}
