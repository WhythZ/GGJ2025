using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabStateMove : CrabStateGround
{
    public CrabStateMove(Animator _anim, string _animBoolName, Crab _crab) : base(_anim, _animBoolName, _crab)
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

        //ˮƽ�ƶ��Ŀ���
        crab.SetVelocity(xInput * crab.moveSpeed, crab.rb.velocity.y);

        //�Ų��ŵ������airState
        if (!crab.isGround && !crab.isBubble)
            crab.stateMachine.ChangeState(crab.fallState);

        //�ڵ��ϻ�����������ˮƽ���룬�����վ��״̬
        if (crab.isGround && xInput == 0)
            crab.stateMachine.ChangeState(crab.idleState);
    }
}
