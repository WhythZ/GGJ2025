using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabStateFall : CrabState
{
    public CrabStateFall(Animator _anim, string _animBoolName, Crab _crab) : base(_anim, _animBoolName, _crab)
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

        //���ڵ���������ϣ���ת��Ϊվ��״̬
        if (crab.isGround || crab.isBubble)
            crab.stateMachine.ChangeState(crab.idleState);

        //��Ծ������Ҳ���������ƶ������ǻ���һ��
        crab.SetVelocity(xInput * crab.airMoveSpeedRate * crab.moveSpeed, crab.rb.velocity.y);
    }
}
