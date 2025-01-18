using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleStateIdle : BubbleState
{
    public BubbleStateIdle(Animator _anim, string _animBoolName, Bubble _bubble) : base(_anim, _animBoolName, _bubble)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        bubble.SetVelocity(0, 0);
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (bubble.isFloating)
            stateMachine.ChangeState(bubble.floatState);
        if (bubble.isFalling)
            stateMachine.ChangeState(bubble.fallState);
    }
}
