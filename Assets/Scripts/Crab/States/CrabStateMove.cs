using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabStateMove : CrabStateGround
{
    public CrabStateMove(Animator _anim, string _animBoolName, Crab _crab) : base(_anim, _animBoolName, _crab)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        //player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);
    }
}
