using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabState : BaseState
{
    protected Crab crab;
    protected StateMachine<CrabState> stateMachine;

    #region Input
    //水平与竖直速度输入属性
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

        //将水平速度与AD两个键位绑定，竖直速度与WS两键位绑定；移动速度可以被大多数动作访问到，故而放到基类中进行定义
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        //持续更新，将yVelocity参数赋值为当前的竖直速度
        crab.anim.SetFloat("yVelocity", crab.rb.velocity.y);
    }
}