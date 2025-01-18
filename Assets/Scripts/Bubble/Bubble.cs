using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    #region Components
    public Animator anim;
    public Rigidbody2D rb;
    #endregion

    #region States
    public StateMachine<BubbleState> stateMachine {  get; private set; }
    public BubbleState idleState {  get; private set; }
    public BubbleState floatState { get; private set; }
    public BubbleState fallState { get; private set; }
    #endregion

    #region Movement
    [Header("Movement")]
    public bool isFloating = true;
    public float floatingSpeed = 0.5f;
    public bool isFalling = false;
    public float fallingSpeed = 0.8f;
    #endregion

    public void Awake()
    {
        #region Components
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        #endregion

        #region States
        stateMachine = new StateMachine<BubbleState>();
        idleState = new BubbleStateIdle(anim, "isIdle", this);
        floatState = new BubbleStateFloat(anim, "isFloat", this);
        fallState = new BubbleStateFall(anim, "isFall", this);
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
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }
    #endregion

    #region Explode
    public void Explode()
    {
        Destroy(this.gameObject);
    }
    #endregion
}
