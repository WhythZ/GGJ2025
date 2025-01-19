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

        //����վ��״̬ʱ��ֹ
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

        //���ڵ��ϻ������ϣ���xˮƽ�����������ʱ��Ž����ƶ�״̬
        if (xInput != 0 && (crab.isGround || crab.isBubble))
            stateMachine.ChangeState(crab.moveState);
    }
}
