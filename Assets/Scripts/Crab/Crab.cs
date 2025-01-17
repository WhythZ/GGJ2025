using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crab : MonoBehaviour
{
    #region Components
    public Animator anim;
    public Rigidbody2D rb;
    #endregion

    #region States
    public StateMachine<CrabState> stateMachine { get; private set; }
    public CrabState idleState { get; private set; }
    public CrabState moveState { get; private set; }
    public CrabState jumpState { get; private set; }
    public CrabState fallState { get; private set; }
    public CrabState attackState { get; private set; }
    #endregion

    public void Awake()
    {
        #region Components
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        #endregion

        #region States
        stateMachine = new StateMachine<CrabState>();
        idleState = new CrabStateIdle(anim, "isIdle", this);
        moveState = new CrabStateMove(anim, "isMove", this);
        jumpState = new CrabStateJump(anim, "isJump", this);
        fallState = new CrabStateFall(anim, "isFall", this);
        attackState = new CrabStateAttack(anim, "isAttack", this);
        #endregion
    }

    public void Start()
    {
        stateMachine.Initialize(idleState);
    }

    public void Update()
    {
        stateMachine.currentState.OnUpdate();
    }

    #region Velocity
    public virtual void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }
    #endregion
}
