using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabStateJump : CrabState
{
    public CrabStateJump(Animator _anim, string _animBoolName, Crab _crab) : base(_anim, _animBoolName, _crab)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        //������Ծ״̬ʱ����һ��˲������ϵ��ٶȣ�����ٶ�ֻ��Ҫ��һ�Σ��ʶ�����Ҫ����Update��һֱ����
        crab.SetVelocity(crab.rb.velocity.x, crab.jumpForce);

        AudioManager.instance.PlaySFX(6, crab.transform);
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        //�����ϵ��ٶ�Ϊ������ת��Ϊ����״̬
        if (crab.rb.velocity.y < 0)
            crab.stateMachine.ChangeState(crab.fallState);

        //��Ծ������Ҳ���������ƶ������ǻ���һ��
        crab.SetVelocity(xInput * crab.airMoveSpeedRate * crab.moveSpeed, crab.rb.velocity.y);
    }
}
