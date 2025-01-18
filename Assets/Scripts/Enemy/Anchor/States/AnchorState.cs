using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorState : BaseState
{
    Anchor anchor;
    StateMachine<AnchorState> stateMachine;

    public AnchorState(Animator _anim, string _animBoolName, Anchor _anchor) : base(_anim, _animBoolName)
    {
        anchor = _anchor;
        stateMachine = _anchor.stateMachine;
    }
}
