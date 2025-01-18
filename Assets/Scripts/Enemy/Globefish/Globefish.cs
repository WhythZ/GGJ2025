using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Globefish : Enemy
{
    #region States
    public StateMachine<GfishState> stateMachine;
    public GfishState fallState {  get; private set; }
    public GfishState swellState {  get; private set; }
    #endregion

    public bool isTouchPlatform = false;
    public float swellDuration = 5f;

    public override void Awake()
    {
        base.Awake();

        #region States
        stateMachine = new StateMachine<GfishState>();
        fallState = new GfishStateFall(anim, "isFall", this);
        swellState = new GfishStateSwell(anim, "isSwell", this);
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

        isTouchPlatform = GetComponentInChildren<PlatformDetector>().signal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.GetComponent<Crab>() != null)
        //{
        //    if (stateMachine.currentState == swellState)
        //        CrabManager.instance.ChangeHealthBy(-1);
        //}

        if (collision.GetComponent<Crab>() != null)
            CrabManager.instance.ChangeHealthBy(-1);

        if (collision.GetComponent<Bubble>() != null)
            collision.GetComponent<Bubble>().Explode();
    }
}
