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

        //水平移动的控制
        crab.SetVelocity(xInput * crab.moveSpeed, crab.rb.velocity.y);

        //脚不着地则进入airState
        if (!crab.isGround && !crab.isBubble)
            crab.stateMachine.ChangeState(crab.fallState);

        //在地上或泡泡上且无水平输入，则进入站立状态
        if (crab.isGround && xInput == 0)
            crab.stateMachine.ChangeState(crab.idleState);
    }
}
