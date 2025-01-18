using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleStateFall : BubbleState
{
    public BubbleStateFall(Animator _anim, string _animBoolName, Bubble _bubble) : base(_anim, _animBoolName, _bubble)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        bubble.isFloating = false;
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        //ÅÝÅÝÏÂ³Á
        bubble.SetVelocity(0, -bubble.fallingSpeed);

        //×ªÒÆµ½ÉÏ¸¡×´Ì¬
        if (!bubble.isFalling && bubble.isFloating)
            stateMachine.ChangeState(bubble.floatState);

        //×ªÒÆµ½ÐüÍ£×´Ì¬
        if (!bubble.isFalling && !bubble.isFloating)
            stateMachine.ChangeState(bubble.idleState);
    }
}
