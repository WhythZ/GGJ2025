using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabStateFall : CrabState
{
    public CrabStateFall(Animator _anim, string _animBoolName, Crab _crab) : base(_anim, _animBoolName, _crab)
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

        //若在地面或泡泡上，则转化为站立状态
        if (crab.isGround || crab.isBubble)
            crab.stateMachine.ChangeState(crab.idleState);

        //跳跃过程中也可以左右移动，但是会慢一点
        crab.SetVelocity(xInput * crab.airMoveSpeedRate * crab.moveSpeed, crab.rb.velocity.y);
    }
}
