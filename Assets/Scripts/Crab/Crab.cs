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
    public CrabState hitState { get; private set; }
    #endregion

    #region Movement
    [Header("Movement Stats")]
    public float moveSpeed = 10f;
    public float airMoveSpeedRate = 0.9f;
    public float jumpForce = 15f;

    //1为右，-1为左；默认面向方向为向右
    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;
    #endregion

    #region Collision
    //地面检测
    [Header("Ground Detect")]
    [SerializeField] protected LayerMask whatIsGround;
    public bool isGround { get; private set; }
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform groundCheck01;
    [SerializeField] protected Transform groundCheck02;
    [SerializeField] protected Transform groundCheck03;

    //泡泡检测
    [Header("Bubble Detect")]
    [SerializeField] protected LayerMask whatIsBubble;
    public bool isBubble { get; private set; }
    [SerializeField] protected Transform bubbleCheck01;
    [SerializeField] protected Transform bubbleCheck02;
    [SerializeField] protected Transform bubbleCheck03;

    //[Header("Basic Collision Info")]
    ////攻击碰撞范围（实体前方的一个圆）
    //public float attackCheckRadius = 1f;
    //public Transform attackCheck;
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
        hitState = new CrabStateHit(anim, "isHit", this);
        #endregion
    }

    public void Start()
    {
        //初始化状态机状态为站立
        stateMachine.Initialize(idleState);
    }

    public void Update()
    {
        //持续更新当前状态
        stateMachine.currentState.OnUpdate();
        //Debug.Log(stateMachine.GetCurrentState().ToString());

        //不断更新实体的所有碰撞检测
        CollisionDetect();

        //左右翻转
        FlipController();
    }

    #region Velocity
    public virtual void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }
    #endregion

    #region Flip
    public virtual void Flip()
    {
        //反转实体
        transform.Rotate(0, 180, 0);
        //把方向的相关判断参数反向
        facingDir *= -1;
        facingRight = !facingRight;
    }
    public virtual void FlipController()
    {
        //开始向右走且朝向为左时，反转
        if (rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        //开始向左走且朝向为右时，反转
        if (rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }
    }
    #endregion

    #region Collision
    public virtual void CollisionDetect()
    {
        bool isGround01 = Physics2D.Raycast(groundCheck01.position, Vector2.down, groundCheckDistance, whatIsGround);
        bool isGround02 = Physics2D.Raycast(groundCheck02.position, Vector2.down, groundCheckDistance, whatIsGround);
        bool isGround03 = Physics2D.Raycast(groundCheck03.position, Vector2.down, groundCheckDistance, whatIsGround);
        //两根检测线只要有一根检测到地板，则视为人物在地板上
        isGround = isGround01 || isGround02 || isGround03;

        bool isBubble01 = Physics2D.Raycast(bubbleCheck01.position, Vector2.down, groundCheckDistance, whatIsBubble);
        bool isBubble02 = Physics2D.Raycast(bubbleCheck02.position, Vector2.down, groundCheckDistance, whatIsBubble);
        bool isBubble03 = Physics2D.Raycast(bubbleCheck03.position, Vector2.down, groundCheckDistance, whatIsBubble);
        isBubble = isBubble01 || isBubble02 || isBubble03;
    }
    public virtual void OnDrawGizmos()
    {
        //地面检测线，从groundCheck子Sprite中心画出的，而非从实体中心画出，以更灵活的进行碰撞检测
        Gizmos.DrawLine(groundCheck01.position, new Vector3(groundCheck01.position.x, groundCheck01.position.y - groundCheckDistance));
        Gizmos.DrawLine(groundCheck02.position, new Vector3(groundCheck02.position.x, groundCheck02.position.y - groundCheckDistance));
        Gizmos.DrawLine(groundCheck03.position, new Vector3(groundCheck03.position.x, groundCheck03.position.y - groundCheckDistance));

        //泡泡检测线
        Gizmos.color = Color.green;
        Gizmos.DrawLine(bubbleCheck01.position, new Vector3(bubbleCheck01.position.x, bubbleCheck01.position.y - groundCheckDistance));
        Gizmos.DrawLine(bubbleCheck02.position, new Vector3(bubbleCheck02.position.x, bubbleCheck02.position.y - groundCheckDistance));
        Gizmos.DrawLine(bubbleCheck03.position, new Vector3(bubbleCheck03.position.x, bubbleCheck03.position.y - groundCheckDistance));

        ////攻击范围的圆
        //Gizmos.color = Color.black;
        //Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion

    #region AnimationTrigger
    public void FinishHit()
    {
        stateMachine.ChangeState(idleState);
    }
    #endregion
}