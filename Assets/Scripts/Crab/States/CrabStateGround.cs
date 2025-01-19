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

        //crab.footBubble.stateMachine.ChangeState(crab.footBubble.floatState);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        //在地面的状态时（包括Idle和Move），若按空格且在地面或泡泡上时，则进入跳跃状态
        if (Input.GetKeyDown(KeyCode.Space) && (crab.isGround || crab.isBubble))
            stateMachine.ChangeState(crab.jumpState);

        ////在地面的状态时（包括Idle和Move），若按空格且泡泡上时，则泡泡进入下沉状态
        //if (Input.GetKeyDown(KeyCode.S) && crab.isBubble)
        //    crab.footBubble.stateMachine.ChangeState(crab.footBubble.fallState);
    }
}
