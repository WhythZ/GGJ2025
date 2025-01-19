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

    //1Ϊ�ң�-1Ϊ��Ĭ��������Ϊ����
    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;
    #endregion

    #region Collision
    //������
    [Header("Ground Detect")]
    [SerializeField] protected LayerMask whatIsGround;
    public bool isGround { get; private set; }
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform groundCheck01;
    [SerializeField] protected Transform groundCheck02;
    [SerializeField] protected Transform groundCheck03;

    //���ݼ��
    [Header("Bubble Detect")]
    [SerializeField] protected LayerMask whatIsBubble;
    public bool isBubble { get; private set; }
    [SerializeField] protected Transform bubbleCheck01;
    [SerializeField] protected Transform bubbleCheck02;
    [SerializeField] protected Transform bubbleCheck03;

    //[Header("Basic Collision Info")]
    ////������ײ��Χ��ʵ��ǰ����һ��Բ��
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
        //��ʼ��״̬��״̬Ϊվ��
        stateMachine.Initialize(idleState);
    }

    public void Update()
    {
        //�������µ�ǰ״̬
        stateMachine.currentState.OnUpdate();
        //Debug.Log(stateMachine.GetCurrentState().ToString());

        //���ϸ���ʵ���������ײ���
        CollisionDetect();

        //���ҷ�ת
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
        //��תʵ��
        transform.Rotate(0, 180, 0);
        //�ѷ��������жϲ�������
        facingDir *= -1;
        facingRight = !facingRight;
    }
    public virtual void FlipController()
    {
        //��ʼ�������ҳ���Ϊ��ʱ����ת
        if (rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        //��ʼ�������ҳ���Ϊ��ʱ����ת
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
        //���������ֻҪ��һ����⵽�ذ壬����Ϊ�����ڵذ���
        isGround = isGround01 || isGround02 || isGround03;

        bool isBubble01 = Physics2D.Raycast(bubbleCheck01.position, Vector2.down, groundCheckDistance, whatIsBubble);
        bool isBubble02 = Physics2D.Raycast(bubbleCheck02.position, Vector2.down, groundCheckDistance, whatIsBubble);
        bool isBubble03 = Physics2D.Raycast(bubbleCheck03.position, Vector2.down, groundCheckDistance, whatIsBubble);
        isBubble = isBubble01 || isBubble02 || isBubble03;
    }
    public virtual void OnDrawGizmos()
    {
        //�������ߣ���groundCheck��Sprite���Ļ����ģ����Ǵ�ʵ�����Ļ������Ը����Ľ�����ײ���
        Gizmos.DrawLine(groundCheck01.position, new Vector3(groundCheck01.position.x, groundCheck01.position.y - groundCheckDistance));
        Gizmos.DrawLine(groundCheck02.position, new Vector3(groundCheck02.position.x, groundCheck02.position.y - groundCheckDistance));
        Gizmos.DrawLine(groundCheck03.position, new Vector3(groundCheck03.position.x, groundCheck03.position.y - groundCheckDistance));

        //���ݼ����
        Gizmos.color = Color.green;
        Gizmos.DrawLine(bubbleCheck01.position, new Vector3(bubbleCheck01.position.x, bubbleCheck01.position.y - groundCheckDistance));
        Gizmos.DrawLine(bubbleCheck02.position, new Vector3(bubbleCheck02.position.x, bubbleCheck02.position.y - groundCheckDistance));
        Gizmos.DrawLine(bubbleCheck03.position, new Vector3(bubbleCheck03.position.x, bubbleCheck03.position.y - groundCheckDistance));

        ////������Χ��Բ
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