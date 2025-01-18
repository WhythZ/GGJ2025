using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GfishStateSwell : GfishState
{
    public GfishStateSwell(Animator _anim, string _animBoolName, Gfish _gfish) : base(_anim, _animBoolName, _gfish)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();

        gfish.SetVelocity(0, 0);
        stateTimer = gfish.swellDuration;
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if(stateTimer <= 0)
            gfish.Die();
    }
}
