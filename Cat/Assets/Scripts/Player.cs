using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    public bool triggerCalled = false;

    public float moveSpeed;

    #region State
    public PlayerStateMachine stateMachine {  get; private set; }
    public IdleState idleState { get; private set; }
    public WalkState WalkState { get; private set; }
    #endregion

    #region Component
    public Rigidbody2D rb;
    public Animator anim;
    #endregion

    private void Awake()//加入新状态
    {
        stateMachine = new PlayerStateMachine();


        idleState = new IdleState(this, stateMachine, "Idle");
        WalkState = new WalkState(this, stateMachine, "Walk");
    }
    private void Start()//获取组件
    {
        stateMachine.Initialized(idleState);
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }

    #region Flip
    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);//旋转函数,transform不需要额外定义，因为他是自带的
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