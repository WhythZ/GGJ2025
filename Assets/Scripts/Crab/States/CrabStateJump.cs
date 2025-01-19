using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabStateJump : CrabState
{
    public CrabStateJump(Animator _anim, string _animBoolName, Crab _crab) : base(_anim, _animBoolName, _crab)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        //进入跳跃状态时，给一个瞬间的向上的速度，这个速度只需要给一次，故而不需要放在Update内一直更新
        crab.SetVelocity(crab.rb.velocity.x, crab.jumpForce);

        AudioManager.instance.PlaySFX(6, crab.transform);
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        //若向上的速度为负，则转换为下落状态
        if (crab.rb.velocity.y < 0)
            crab.stateMachine.ChangeState(crab.fallState);

        //跳跃过程中也可以左右移动，但是会慢一点
        crab.SetVelocity(xInput * crab.airMoveSpeedRate * crab.moveSpeed, crab.rb.velocity.y);
    }
}
