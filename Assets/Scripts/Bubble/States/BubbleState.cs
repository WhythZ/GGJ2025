using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleState : BaseState
{
    protected Bubble bubble;
    protected StateMachine<BubbleState> stateMachine;

    public BubbleState(Animator _anim, string _animBoolName, Bubble _bubble) : base(_anim, _animBoolName)
    {
        bubble = _bubble;
        stateMachine = _bubble.stateMachine;
    }
}
