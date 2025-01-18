using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabStateGround : CrabState
{
    public CrabStateGround(Animator _anim, string _animBoolName, Crab _crab) : base(_anim, _animBoolName, _crab)
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

        //在地面的状态时（包括Idle和Move），若按空格且在地面或泡泡上时，则进入跳跃状态
        if (Input.GetKeyDown(KeyCode.Space) && (crab.isGround || crab.isBubble))
            stateMachine.ChangeState(crab.jumpState);
    }
}
