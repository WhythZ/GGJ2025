using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    #region Components
    Animator anim;
    Rigidbody2D rb;
    #endregion

    #region States
    public StateMachine<BubbleState> stateMachine {  get; private set; }
    public BubbleState idleState {  get; private set; }
    public BubbleState floatingState { get; private set; }
    public BubbleState fallingState { get; private set; }
    #endregion

    public void Awake()
    {
        #region Components
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        #endregion

        #region States
        idleState = new BubbleState(anim, "isIdle");
        floatingState = new BubbleState(anim, "isFloating");
        fallingState = new BubbleState(anim, "isFalling");
        #endregion
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        stateMachine.currentState.OnUpdate();
    }
}
