using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class BubbleStateFloat : BubbleState
{
    public BubbleStateFloat(Animator _anim, string _animBoolName, Bubble _bubble) : base(_anim, _animBoolName, _bubble)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        bubble.isFalling = false;
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        //�����ϸ�
        bubble.SetVelocity(0, bubble.floatingSpeed);

        //ת�Ƶ��³�״̬
        if (!bubble.isFloating && bubble.isFalling)
            stateMachine.ChangeState(bubble.floatState);

        //ת�Ƶ���ͣ״̬
        if (!bubble.isFloating && !bubble.isFalling)
            stateMachine.ChangeState(bubble.idleState);
    }
}
