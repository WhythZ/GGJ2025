using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GfishState : BaseState
{
    protected Globefish gfish;
    protected StateMachine<GfishState> stateMachine;

    public GfishState(Animator _anim, string _animBoolName, Globefish _gfish) : base(_anim, _animBoolName)
    {
        gfish = _gfish;
        stateMachine = _gfish.stateMachine;
    }
}
