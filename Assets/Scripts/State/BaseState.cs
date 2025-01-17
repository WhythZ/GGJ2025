using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class BaseState
{
    #region Initialize
    //管理该状态的Animator
    protected Animator anim;
    //该状态在对应Animator内关联的bool值名称
    protected string animBoolName;
    #endregion

    #region Control
    //该状态的计时器
    protected float stateTimer;
    //该状态的触发记录器
    protected bool stateActionFinished;
    #endregion

    public BaseState(Animator _anim, string _animBoolName)
    {
        this.anim = _anim;
        this.animBoolName = _animBoolName;
    }

    public virtual void OnEnter()
    {
        //赋值这个动作的激活状态为真
        anim.SetBool(animBoolName, true);

        //每次进入新的状态时，赋值这个触发为假
        stateActionFinished = false;
    }

    public virtual void OnUpdate()
    {
        //计数器每1s递减1单位数值
        stateTimer -= Time.deltaTime;
    }

    public virtual void OnExit()
    {
        //赋值当前状态的激活状态为假
        anim.SetBool(animBoolName, false);
    }

    public virtual void TriggerWhenFinished()
    {
        stateActionFinished = true;
    }
}
