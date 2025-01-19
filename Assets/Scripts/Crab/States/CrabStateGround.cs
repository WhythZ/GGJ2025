using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabStateGround : CrabState
{
    //private float jumpOptimizeTimer = 0;
    //private float jumpOptimizeTime = 0.1f;

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

        //�ڵ����״̬ʱ������Idle��Move���������ո����ڵ����������ʱ���������Ծ״̬
        if (Input.GetKeyDown(KeyCode.Space) && (crab.isGround || crab.isBubble))
            stateMachine.ChangeState(crab.jumpState);

        ////�ڵ����״̬ʱ������Idle��Move���������ո���������ʱ���������Ծ״̬
        //if (Input.GetKeyDown(KeyCode.S) && crab.isBubble)
        //    crab.footBubble.stateMachine.ChangeState(crab.footBubble.fallState);
    }
}
