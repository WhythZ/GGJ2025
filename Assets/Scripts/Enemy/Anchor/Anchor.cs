using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : Enemy
{
    #region
    public StateMachine<AnchorState> stateMachine;
    public AnchorState fallState;
    public AnchorState returnState;
    public AnchorState breakState;
    #endregion

    public override void Awake()
    {
        base.Awake();

        #region States
        stateMachine = new StateMachine<AnchorState>();
        fallState = new AnchorStateFall(anim, "isFall", this);
        returnState = new AnchorStateReturn(anim, "isReturn", this);
        breakState = new AnchorStateBreak(anim, "isBreak", this);
        #endregion
    }

    public override void Start()
    {
        base.Start();

        stateMachine.Initialize(fallState);
    }

    public override void Update()
    {
        base.Update();
        stateMachine.currentState.OnUpdate();
    }
}
