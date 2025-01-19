using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabStateHit : CrabState
{
    public CrabStateHit(Animator _anim, string _animBoolName, Crab _crab) : base(_anim, _animBoolName, _crab)
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

        if (stateMachine.formerState == crab.idleState || stateMachine.formerState == crab.moveState)
            crab.SetVelocity(xInput * crab.moveSpeed, crab.rb.velocity.y);
        if (stateMachine.formerState == crab.jumpState || stateMachine.formerState == crab.fallState)
            crab.SetVelocity(xInput * crab.airMoveSpeedRate * crab.moveSpeed, crab.rb.velocity.y);
    }
}
