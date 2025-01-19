using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleStateExplode : BubbleState
{
    public BubbleStateExplode(Animator _anim, string _animBoolName, Bubble _bubble) : base(_anim, _animBoolName, _bubble)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        AudioManager.instance.PlaySFX(12, bubble.transform);
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
