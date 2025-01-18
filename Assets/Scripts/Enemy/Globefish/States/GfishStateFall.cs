using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GfishStateFall : GfishState
{
    public GfishStateFall(Animator _anim, string _animBoolName, Globefish _gfish) : base(_anim, _animBoolName , _gfish)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        gfish.SetVelocity(0, -gfish.moveSpeed);

        if (gfish.isTouchPlatform)
            stateMachine.ChangeState(gfish.swellState);
    }
}
