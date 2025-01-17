using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class BaseState
{
    #region Initialize
    //�����״̬��Animator
    protected Animator anim;
    //��״̬�ڶ�ӦAnimator�ڹ�����boolֵ����
    protected string animBoolName;
    #endregion

    #region Control
    //��״̬�ļ�ʱ��
    protected float stateTimer;
    //��״̬�Ĵ�����¼��
    protected bool stateActionFinished;
    #endregion

    public BaseState(Animator _anim, string _animBoolName)
    {
        this.anim = _anim;
        this.animBoolName = _animBoolName;
    }

    public virtual void OnEnter()
    {
        //��ֵ��������ļ���״̬Ϊ��
        anim.SetBool(animBoolName, true);

        //ÿ�ν����µ�״̬ʱ����ֵ�������Ϊ��
        stateActionFinished = false;
    }

    public virtual void OnUpdate()
    {
        //������ÿ1s�ݼ�1��λ��ֵ
        stateTimer -= Time.deltaTime;
    }

    public virtual void OnExit()
    {
        //��ֵ��ǰ״̬�ļ���״̬Ϊ��
        anim.SetBool(animBoolName, false);
    }

    public virtual void TriggerWhenFinished()
    {
        stateActionFinished = true;
    }
}
