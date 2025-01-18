using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabState : BaseState
{
    protected Crab crab;
    protected StateMachine<CrabState> stateMachine;

    #region Input
    //ˮƽ����ֱ�ٶ���������
    public float xInput { get; private set; }
    public float yInput { get; private set; }
    #endregion

    public CrabState(Animator _anim, string _animBoolName, Crab _crab) : base(_anim, _animBoolName)
    {
        crab = _crab;
        stateMachine = _crab.stateMachine;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        //��ˮƽ�ٶ���AD������λ�󶨣���ֱ�ٶ���WS����λ�󶨣��ƶ��ٶȿ��Ա�������������ʵ����ʶ��ŵ������н��ж���
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        //�������£���yVelocity������ֵΪ��ǰ����ֱ�ٶ�
        crab.anim.SetFloat("yVelocity", crab.rb.velocity.y);
    }
}