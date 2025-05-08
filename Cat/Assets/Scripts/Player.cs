using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    public bool triggerCalled = false;

    public float moveSpeed;

    public float jumpforce;
    public LayerMask playerLayer;

    public bool isGroundDetected;
    public LayerMask whatIsGround;
    public Transform groundCheck;

    #region State
    public PlayerStateMachine stateMachine {  get; private set; }
    public IdleState idleState { get; private set; }
    public WalkState walkState { get; private set; }
    public JumpState JumpState { get; private set; }
    public GrabState grabState { get; private set; }
    public PushState pushState { get; private set; }
    public DoumaoState playState { get; private set; }
    public YaodianxianState bitState { get; private set; }
    public SlideState slideState { get; private set; }
    #endregion

    #region Component
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;
    #endregion

    private void Awake()//加入新状态
    {
        stateMachine = new PlayerStateMachine();


        idleState = new IdleState(this, stateMachine, "Idle");
        walkState = new WalkState(this, stateMachine, "Walk");
        JumpState = new JumpState(this, stateMachine, "Jump");
        grabState = new GrabState(this, stateMachine, "Grab");
        pushState = new PushState(this, stateMachine, "Push");
        playState = new DoumaoState(this, stateMachine, "Play");
        bitState  = new YaodianxianState(this, stateMachine, "Bit");
        slideState = new SlideState(this, stateMachine, "Slide");

        instance = this;
    }
    private void Start()//获取组件
    {
        stateMachine.Initialized(idleState);
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        stateMachine.currentState.Update();
        Debug.Log(stateMachine.currentState);
        Debug.Log(triggerCalled);
        isGroundDetected = Physics2D.Raycast(groundCheck.position, Vector3.down, 1f,whatIsGround);
    }

    #region Flip
    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        Vector3 theScale = anim.gameObject.transform.localScale;
        theScale.x = facingRight ? 1 : -1;
        anim.gameObject.transform.localScale = theScale;
    }//翻转函数

    public virtual void FlipController(float _x)//目前设置x，目的时能在空中时也能转身
    {
        if (_x > 0 && !facingRight)//当速度大于0且没有朝右时，翻转
            Flip();
        else if (_x < 0 && facingRight)
            Flip();
    }
    #endregion

    #region Velocity
    public void SetZeroVelocity()
    {
        //if (isKnocked) return;
        rb.velocity = new Vector2(0, 0);
    }

    public void SetVelocity(float _xVelociuty, float _yVelociuty)
    {
        //if (isKnocked) return;

        rb.velocity = new Vector2(_xVelociuty, _yVelociuty);
        FlipController(_xVelociuty);
    }
    #endregion
    public void AnimationFinished(Player player)
    {
        player.triggerCalled = true;
    }
}