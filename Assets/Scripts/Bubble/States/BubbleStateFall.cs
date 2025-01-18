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

        //�����³�
        bubble.SetVelocity(0, -bubble.fallingSpeed);

        //ת�Ƶ��ϸ�״̬
        if (!bubble.isFalling && bubble.isFloating)
            stateMachine.ChangeState(bubble.floatState);

        //ת�Ƶ���ͣ״̬
        if (!bubble.isFalling && !bubble.isFloating)
            stateMachine.ChangeState(bubble.idleState);
    }
}
