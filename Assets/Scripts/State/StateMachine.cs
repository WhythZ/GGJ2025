using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<S> where S : BaseState
{
    public S currentState { get; private set; }

    public S formerState { get; private set; }

    public void Initialize(S _startState)
    {
        //设定这个状态机的初始状态，并进入该状态
        this.currentState = _startState;
        currentState.OnEnter();
    }

    public void ChangeState(S _newState)
    {
        //退出上一个状态（即把其关联的参数设置为false）
        currentState.OnExit();
        //在转换状态之前，记录下是从什么状态转换到了下一个状态
        formerState = currentState;
        //设置当前状态为输入的状态，然后进入该状态（即把其关联的参数设置为true）
        currentState = _newState;
        currentState.OnEnter();
    }
}
