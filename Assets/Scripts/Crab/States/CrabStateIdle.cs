using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabStateIdle : CrabStateGround
{
    public CrabStateIdle(Animator _anim, string _animBoolName, Crab _crab) : base(_anim, _animBoolName, _crab)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        //进入站立状态时静止
        crab.SetVelocity(0, 0);
        if (crab.isBubble)
            AudioManager.instance.PlaySFX(7, crab.transform);
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        //当在地上或泡泡上，且x水平方向有输入的时候才进入移动状态
        if (xInput != 0 && (crab.isGround || crab.isBubble))
            stateMachine.ChangeState(crab.moveState);
    }
}
