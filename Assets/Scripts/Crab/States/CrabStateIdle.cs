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
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
